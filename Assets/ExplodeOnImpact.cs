using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public float velocityThreshold = 1f;

    ParticleSystem explodeParticles;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1f) // Then explode
        {
            explodeParticles.Play();
        }
    }

    private void Start()
    {
        explodeParticles = GetComponentInChildren<ParticleSystem>(); // Partucle system must be a child of this game object! E.g. the wrecking ball is the parent
    }
}
