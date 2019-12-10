using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    public Transform button; // Reference to the red button (the renderer)

    public Transform closedPosition; // Where to move button when pushed

    Vector3 openPosition; // Remember original "open" position

    AudioSource source;

    public delegate void ButtonPressedEvent(); // Declaring the structure of a new delegate, which I've called ButtonPressedEvent. This is not an instance.
    public ButtonPressedEvent OnButtonPress; // This is an instance of the delegate ButtonPressedEvent. Functions (from this script or other scripts) can "subscribe" to this delegate instance.

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

        OnButtonPress(); // This is going to execute functions that have "subscribed" to OnButtonPress
    }

    // When hand (or any object with collider + Rigidbody) leaves button sense
    private void OnTriggerExit(Collider other)
    {
        button.position = openPosition; // Reset to original position
    }
}
