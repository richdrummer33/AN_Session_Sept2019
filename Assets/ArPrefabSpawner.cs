using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArPrefabSpawner : MonoBehaviour
{
    public ARRaycastManager raycastManager; // I need reference to an AR raycast manager

    public GameObject prefab; // I need a reference to the prebab that I want to instantiate in AR (presumably on a plane)

    private GameObject prefabInstance; // This will hold a reference to the prefab we created

    // Update is called once per frame
    void Update()
    {

        List<ARRaycastHit> hits = new List<ARRaycastHit>(); // A variable to hold raycast info, i.e. to get the position in our 3d world that we hit (presumably on a plane)
                
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // If we are touching screen
        {
            Vector3 touchPoint = Input.GetTouch(0).position;
            touchPoint.z = 0f;
            Vector2 cameraCenter = Camera.current.ViewportToScreenPoint(touchPoint); // Get the center position of the screen - i.e. the point from which we raycast from

            if (raycastManager.Raycast(cameraCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))  // Perform raycast - info dumped into "hits" 
            {
                if (hits.Count > 0) // Check that the raycast in fact did hit a collider
                {
                    if (prefabInstance == null) // If we haven't yet created an instance, make one
                    {
                        prefabInstance = Instantiate(prefab, hits[0].pose.position, prefab.transform.rotation);  // Create prefab on plane!
                    }
                    else
                    {
                        prefabInstance.transform.position = hits[0].pose.position;
                    }
                }
            }
        }
    }
}
 