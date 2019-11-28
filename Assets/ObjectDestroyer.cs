using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // When object falls off terrain and colldies with this invisible plane!
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.ObjectDestroyed(other.gameObject); // Want to increment a tally of the destroyed objects (for the game) - call a function in the GameManager to increment the tally

        Destroy(other.gameObject); // Destroy object that passes through
    }
}
