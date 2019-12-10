using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void Interact() // virtual makes this function "overrideable" (will be inherited by child classes)
    {
        Debug.Log("Interaction started!");

        // Common features go here
        // e.g. Play a sound
    }

    public virtual void StopInteracting()
    {
        Debug.Log("Interaction stopped!");

        // Common features go here
        // e.g. Play a sound
    }

    public virtual void OnGrabbed()
    {
        // Common features go here
    }

    public virtual void OnReleased()
    {
        // Common features go here
    }
}
