using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interact and StopInteracting functions to be called by the hand (grab script) using SendMessage command
/// </summary>
public class InteractablePaintbrush : MonoBehaviour
{
    public GameObject paintTrailPrefab; // Prefab of the paint trail that will be drawn when we pull the trigger on the controller

    GameObject currentPaintTrail; // The current paint trail that we are painting (while holding the trigger)

    Material paintMaterial; // The paint applied to the brush and paint trail alike

    // A generically named function that can be called from our grab script (Xr or sim hand grab)
    // To be called on trigger-pull to start painting
    private void Interact()
    {
        if (paintMaterial != null) // Check that our brush has paint!
        {
            currentPaintTrail = Instantiate(paintTrailPrefab, transform.position, transform.rotation, transform); // Create paint trail that is child of paintbrush - will follow brush and paint!
            currentPaintTrail.GetComponent<Renderer>().material = paintMaterial; // Apply the paint material to the trail's Renderer
        }
    }

    // Stop painting, but don't delete it!
    private void StopInteracting()
    {
        currentPaintTrail.transform.SetParent(null); // Unparent so stops following the brush
    }

    // Take on the color of the paint when brush touches paint!
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paint") // Check that the object we collided with is actuially paint first
        {
            paintMaterial = collision.gameObject.GetComponent<Renderer>().material; // Take note of the paint's material (color)!
            GetComponent<Renderer>().material = paintMaterial; // Apply paint material to brush
        }
    }
}
