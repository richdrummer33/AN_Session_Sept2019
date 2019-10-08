using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandController : MonoBehaviour // This declares my script - the name of it being SimHandController
{
    // public vars: Can see and edit in the inspector and are accessible from other scripts
    // private vars: Cannot see/edit in the inspector and are not* accessible from other scripts

    float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start() 
    {
       
    }

    // Update is called once per frame (typically 60 frames every second)
    void Update()
    {
        // REview this (one student had to leave )!!! if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(this.transform.forward * Time.deltaTime * moveSpeed); // Translate is a function that moves the transform (in this case, "this.tranform"). this.transform.forward has length of 1m
        }

        // Time.deltaTime is the duration of the last frame - how long the last frame took, typically 1/60sec
    }

    void RichardsFunction() // White becuase it's a custom function
    {
        // I can put my code in here too
    }
}
