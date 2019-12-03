using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    public List<Rigidbody> carRigidbodies = new List<Rigidbody>();

    public Transform button; // Reference to the red button (the renderer)

    public Transform closedPosition; // Where to move button when pushed

    Vector3 openPosition; // Remember original "open" position

    AudioSource source;
    
    void Start()
    {
        openPosition = button.position; // Take note of start positino before pressed!

        source = GetComponent<AudioSource>();
    }

    // When hand (or any object with collider + Rigidbody) touches button sense
    private void OnTriggerEnter(Collider other)
    {
        button.position = closedPosition.position; // move the button!

        source.Play();
                
        //Step through each element in the list, and apply force
        /*foreach(Rigidbody rb in carRigidbodies)
        {
            rb.AddForce(Vector3.left * 15f, ForceMode.Impulse); // Do something to "rb"
            Debug.Log("rb: " + rb.gameObject.name);
        }

        for (int i = 0; i < carRigidbodies.Count; i++)
        {
            carRigidbodies[i].AddForce(Vector3.left * 15f, ForceMode.Impulse);
            Debug.Log("index: " + i);
        }
        */
    }

    // When hand (or any object with collider + Rigidbody) leaves button sense
    private void OnTriggerExit(Collider other)
    {
        button.position = openPosition; // Reset to original position
    }
}
