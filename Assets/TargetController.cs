using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public Text uiText; // Reference to the UI canvas text

    private int numHits = 0; 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            uiText.text = "Hits=" + numHits; // Can use "+" to append numbers to a string - unity auto changes number to string when use the + after some ""

            numHits++; // Short-hand for incrementing this int by 1 (adds 1 to itself)
        }
    }
}