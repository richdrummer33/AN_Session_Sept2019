using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    AudioSource source;

    public float velocityThreshold = 1f; // meters per second

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > velocityThreshold) // If so, play sound
        {
            source.volume = Mathf.Clamp(collision.relativeVelocity.magnitude * 0.25f, 0.1f, 1f); // Volume modulated by the velocity

            source.pitch = Mathf.Clamp(collision.relativeVelocity.magnitude * 0.5f, 0.1f, 2f); // Pitch modulated by the velocity

            source.Play();
        }
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
