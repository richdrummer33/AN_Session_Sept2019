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

    // Start is called before the first frame update
    void Start() 
    {
       // Code
    }

    // Update is called once per frame (typically 60 frames every second)
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) // GetKeyDown only activates *at the moment* which the key is pressed (in this case Mouse0, or the left mouse button)
        {
            GameObject instance;

            instance = Instantiate(prefab, this.transform.position, prefab.transform.rotation);

            instance.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W)) // Checks for keypress "W" on keyboard
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed); // Translate is a function that moves the transform (in this case, "this.tranform"). this.transform.forward has length of 1m
        }
        else if(Input.GetKey(KeyCode.S)) // Checks for keypress "S" on keyboard. If pressed, move backwards
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        if(Input.GetKey(KeyCode.A)) // Move left
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if(Input.GetKey(KeyCode.D)) // Move Right
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        if(Input.GetKey(KeyCode.E)) // Move up
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        else if(Input.GetKey(KeyCode.Q)) // Move down
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }

        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World); // Rotate/pivot left and right

        this.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed, Space.Self);

        // Time.deltaTime is the duration of the last frame - how long the last frame took, typically 1/60sec
    }

    void RichardsFunction() // White becuase it's a custom function
    {
        // I can put my code in here too
    }
}
