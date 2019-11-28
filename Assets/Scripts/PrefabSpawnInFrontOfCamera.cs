using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabSpawnInFrontOfCamera : MonoBehaviour
{  
    public GameObject prefab; // I need a reference to the prebab that I want to instantiate in AR (presumably on a plane)

    private GameObject prefabInstance; // This will hold a reference to the prefab we created
       
    void Update()
    {    
        if (Input.touchCount > 0) // If we are touching screen
        {
            if (prefabInstance == null) // If we haven't yet created an instance, make one
            {
                prefabInstance = Instantiate(prefab, Camera.main.transform.position + Camera.main.transform.forward, prefab.transform.rotation);  // Instantiate prefab 1meter in front of camera's position
            }
        }
    }
}
