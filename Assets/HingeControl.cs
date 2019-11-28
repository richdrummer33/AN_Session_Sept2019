using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script should attach to the lever arm with the Hinge joint
/// </summary>
public class HingeControl : MonoBehaviour
{
    HingeJoint joint; // Needed to get current angle 

    float angleLimit;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>(); // HingeJoint must exist on this game object!
        angleLimit = joint.limits.max; // Take note of max angular extent of lever (limit) in degrees
    }

    // Can use this to control things (like move a cube fwd/backward)
    public float NormalizedControlValue() // Returns numnber between -1 and +1 - percent how much lever pushed/pulled
    {
        float normalizedValue = joint.angle / angleLimit;
        return normalizedValue; 
    }
}
