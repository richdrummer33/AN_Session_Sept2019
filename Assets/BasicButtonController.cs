using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
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
    }

    // When hand (or any object with collider + Rigidbody) leaves button sense
    private void OnTriggerExit(Collider other)
    {
        button.position = openPosition; // Reset to original position
    }
}
