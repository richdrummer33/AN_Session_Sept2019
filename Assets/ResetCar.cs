using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When reset button is pushed, move this car back to its original position and rotation
/// </summary>
public class ResetCar : MonoBehaviour
{
    Vector3 originalPosition;
    Quaternion originalRotation;

    public BasicButtonController resetButton;
    
    void Start()
    {
        originalPosition = transform.position; // "Remember" orig pos and rotation
        originalRotation = transform.rotation;

        resetButton.OnButtonPress += ResetPositionAndRotation; // Subscrive ResetPositionAndRotation function - this function will run when resetButton is pressed
    }
    
    void ResetPositionAndRotation()
    {
        // When resetting a moving rigidbody, must force the rigidbodyt velocity to 0m/s
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        transform.position = originalPosition; // Move back home
        transform.rotation = originalRotation;
    }
}
