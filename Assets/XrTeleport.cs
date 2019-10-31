using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a teleport script that will move the Xr Rig when the Menu button is pressed, then released when pointing at a collider 
/// Will move player to the point on the collider which was hit by a raycast
/// This script can go on either hand (left/right)
/// </summary>
public class XrTeleport : MonoBehaviour
{
    public Transform xrRig; // We need a reference to the Xr rig, so we can move it!

    public LineRenderer line; // Need line renderer to visualize where I am pointing, where we will teleport!

    Vector3 hitPosition; // To record the last valid position that was hit by our raycast
    // Handy note: default value of a Vector 3 is 0,0,0 for x,y, and z

    public string teleportButtonInputName; // The name of the button on the controller that we're using for teleport (which is defined in the Project Settings --> Inputs list)

    bool hitIsValid = false; // A flag to note when the raycast hit is valid (e.g. we're aiming at a collider that we can teleport to, not empty space)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, this.transform.position); // Have line start position (origin of the laser) always follow the hand!

        // When holding down the teleport button (TBD), we need to perform a function "Raycast" that will "sense" the point on the collider which we are aiming at
        // then, we take that point and draw the laser. Once we release the teleport button, then we will make the xrRig move (immediately) to that point/position

        RaycastHit hitInfo;

        if (Input.GetButton(teleportButtonInputName)) // Evaluate if we're pressing the teleport button, before running the raycast and laser code 
        {
            line.enabled = true; // When holding button, laser should be on!

            // Casts an invisible line, and returns "true" if a collider is hit, or false if nothing is hit
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 1000f)) // out hitInfo: The Raycast function "dumps" information about what was hit and where it was hit - dumps this info into the hitInfo variable
            {
                hitPosition = hitInfo.point; // Receord the position hit by our raycast

                line.SetPosition(1, hitPosition); // Set the end position of our laser pointer to be the point that was hit on the collider!

                hitIsValid = true; // Take note that the hit is valid!
            }
            else //  Let's still draw a graphic (e.g. laser line) to indicate where we're pointing even if something's not hit (still wanna see where we're pointing)
            {
                Vector3 laserEndPoint = transform.position + transform.forward * 100f; // Define the laser's end position some distance "forward" in the direction we are pointing the controller

                line.SetPosition(1, laserEndPoint); // Set the position of the laser end-point here

                hitIsValid = false; // Take note hit is invalid! (Pointing off into empty space)
            }
        }

        if(Input.GetButtonUp(teleportButtonInputName)) // Evaluate the moment at which the teleport button is *released* - upon release, attempt to teleport
        {
            line.enabled = false; // When release the button, laser should turn off!

            // Attempt teleport!
            if(hitIsValid == true) // Check if we are pointing at some collider
            {
                Vector3 offsetCorrection = xrRig.position - Camera.main.transform.position; // Calculate the offset from the head to the xrRig's position so that our head is centered on the hitPosition (not the center of our room!)
                offsetCorrection.y = 0f; // Make the vertical compoent of the offset correction = 0 (don't want the rig to raise or lower!!)

                xrRig.position = hitPosition + offsetCorrection;  // Move the XR Rig with the offset correction 
            }

            hitIsValid = false; // Precaution
        }
    }
}
