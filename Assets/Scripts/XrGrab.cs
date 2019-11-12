using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    // public vars: Can see and edit in the inspector and are accessible from other scripts
    // private vars: Cannot see/edit in the inspector and are not* accessible from other scripts

    float moveSpeed = 5f;

    float rotationSpeed = 80f;

    public GameObject prefab; // This is what we will spawn (i.e. "Instantiate") to fire/launch it when click left mouse button

    private float speedMultiplier = 1f;

    public GameObject collidingObject; // This will reference "remeber" the object that we are colliding with (touching)

    public GameObject heldObject; // This will "remember" the object we are holding, so that we know what to let go of

    public Animator anim; // This is a reference to the Animator component attached to the sim hand game object (3d model) - this is not a reference to the animator controller file*

    // XR specific variables:
    private bool gripIsPressed = false;

    public string gripInputName; // The name of the grip as per the Inputs setup in Project Settings

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject; // Remember the object we are colliding with/touching 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject) // Just in case we are colliding with more than 1 object at same time
        {
            collidingObject = null; // null means empty variable "empty bucket" -- "forget" the object we are no longer touching
        }
    }

    // Update is called once per frame (typically 60 frames every second)
    void Update()
    {
        if (Input.GetAxis(gripInputName) > 0.5f && gripIsPressed == false) // We want to check the grip button - on the moment it is pressed more than 50%, then execute the code within (to grab)
        {
            anim.SetBool("Closed", true); // Makes the Closed parameter in the anim controller "true" - cause the close anim to run

            if (collidingObject != null) // If we're touching a object 
            {
                GrabObject();
            }

            gripIsPressed = true; // Makes sure that the code in this if statement executes only once when we squeeze grip
        }
        else if (Input.GetAxis(gripInputName) < 0.5f && gripIsPressed == true) // Right mouse button - if released, then release the held object, if we have one!
        {
            anim.SetBool("Closed", false); // Makes the Closed parameter in the anim controller "false"

            if (heldObject != null) // If we are in fact holding something
            {
                ReleaseObject();
            }

            gripIsPressed = false; // Makes sure that the code in this "else if" statement executes only once when we let go of the grip
        }

        // Keeping this (below) is OK! We can change this to shoot paintballs with the VR controller button instead of mouse 0

        if (Input.GetKeyDown(KeyCode.Mouse0)) // GetKeyDown only activates *at the moment* which the key is pressed (in this case Mouse0, or the left mouse button)
        {
            GameObject instance;

            instance = Instantiate(prefab, this.transform.position, prefab.transform.rotation);

            instance.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
        }
    }

    private void GrabObject()
    {
        Rigidbody otherRigidbody = collidingObject.GetComponent<Rigidbody>(); // Get a reference to the RB of hte colliding object

        if (otherRigidbody != null) // If collidingObject does have a rigidbody
        {
            collidingObject.transform.parent = this.transform;

            otherRigidbody.isKinematic = true;

            heldObject = collidingObject; // Remember what we grabbed! For ReleaseObject() function (TBD)
        }
    }

    private void ReleaseObject()
    {
        heldObject.transform.parent = null; // Un-parents the held object (i.e. makes it no longer a child of my hand - stops following my hand)

        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Let it respond to external forces (e.g. gravity and the floor)

        heldObject = null; // Forget we are holding it (cause we aint no more)
    }
}
