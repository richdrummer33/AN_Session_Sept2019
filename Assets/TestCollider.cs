using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("This box collided with " + other.name);

        Instantiate(prefab, this.transform.position + Vector3.up, prefab.transform.rotation);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("This box had a non-trigger collision with " + collision.gameObject.name);

        Instantiate(prefab, this.transform.position + Vector3.up, prefab.transform.rotation);
    }
}
