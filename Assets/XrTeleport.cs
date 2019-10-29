using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrTeleport : MonoBehaviour
{
    public Transform xrRig; // We need a reference to the Xr rig, so we can move it!
    public LineRenderer line; // Need line renderer to visualize where I am pointing, where we will teleport!
    
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
    }
}
