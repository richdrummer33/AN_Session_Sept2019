using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLatcher : MonoBehaviour
{
    public float latchForce = 10f; // How much force to apply to the lever arm (to make it snap into latched position)

    public GameObject leverArm; // Lever of this prefab! 

    public GameObject prefab; // To instantiate on latch

    public Transform spawnPosition; // Where to instantiate (spawn == instantiate)

    // Apply force in this game-object's x-direction when the lever enters this collider
    private void OnTriggerStay(Collider other) // Function is called every physics step (50 times per second) when a collision is happening
    {
        if(other.gameObject == leverArm) // Check that what collided is the lever
        {
            other.GetComponent<Rigidbody>().AddForce(transform.right * latchForce);
        }
    }

    // Only runs at moment when lever enters the collider (or anyt other collider enters)
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == leverArm) // Check that what collided is the lever
        {
            Instantiate(prefab, spawnPosition.position, prefab.transform.rotation); // Spawn prefab at position of "spawnPosition"
        }
    }
}
