using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandController : MonoBehaviour // This declares my script - the name of it being SimHandController
{
    // public vars: Can see and edit in the inspector and are accessible from other scripts
    // private vars: Cannot see/edit in the inspector and are not* accessible from other scripts

    float moveSpeed = 5f;

    float rotationSpeed = 80f;

    public GameObject prefab; // This is what we will spawn (i.e. "Instantiate") to fire/launch it when click left mouse button

    private float speedMultiplier = 1f;

    public GameObject collidingObject; // This will reference "remeber" the object that we are colliding with (touching)

    public GameObject heldObject; // This will "remember" the object we are holding, so that we know what to let go of

    // Start is called before the first frame update
    void Start() 
    {
       // Code
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject; // Remember the object we are colliding with/touching 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject) // Just in case we are colliding with more than 1 object at same time
        {
            collidingObject = null; // null means empty variable "empty bucket" -- "forget" the object we are no longer touching
        }
    }

    // Update is called once per frame (typically 60 frames every second)
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)) // Right mouse button - if pushed, then do the grab
        {
            if (collidingObject != null)
            {
                GrabObject();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) // GetKeyDown only activates *at the moment* which the key is pressed (in this case Mouse0, or the left mouse button)
        {
            GameObject instance; 

            instance = Instantiate(prefab, this.transform.position, prefab.transform.rotation);

            instance.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
        }

        #region movement

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedMultiplier = 2.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedMultiplier = 1f;
        }

        if (Input.GetKey(KeyCode.W)) // Checks for keypress "W" on keyboard
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * speedMultiplier); // Translate is a function that moves the transform (in this case, "this.tranform"). this.transform.forward has length of 1m
        }
        else if(Input.GetKey(KeyCode.S)) // Checks for keypress "S" on keyboard. If pressed, move backwards
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed * speedMultiplier);
        }

        if(Input.GetKey(KeyCode.A)) // Move left
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed * speedMultiplier);
        }
        else if(Input.GetKey(KeyCode.D)) // Move Right
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * speedMultiplier);
        }

        if(Input.GetKey(KeyCode.E)) // Move up
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * speedMultiplier);
        }
        else if(Input.GetKey(KeyCode.Q)) // Move down
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed * speedMultiplier);
        }


        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World); // Rotate/pivot left and right

        this.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed, Space.Self);

        #endregion
        // Time.deltaTime is the duration of the last frame - how long the last frame took, typically 1/60sec
    }

    private void GrabObject()
    {
        Rigidbody otherRigidbody = collidingObject.GetComponent<Rigidbody>(); // Get a reference to the RB of hte colliding object

        if(otherRigidbody != null) // If collidingObject does have a rigidbody
        {
            collidingObject.transform.parent = this.transform;

            otherRigidbody.isKinematic = true;

            heldObject = collidingObject; // Remember what we grabbed! For ReleaseObject() function (TBD)
        }
    }

    void RichardsFunction() // White becuase it's a custom function
    {
        // I can put my code in here too
    }
}
