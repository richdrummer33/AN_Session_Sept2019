using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // By being static, we can access the variable "instance" from anywhere
    public static GameManager instance; // Static - makes this variable belong to the GameManager class itself 

    public int numObjectsDestroyed = 0; // Tally
    int numObjectsToDestroy;

    public Text uiText; // To display num objects destroyed and timer

    public float timeRemaining = 30f; // Countdown timer - when reaches 0, player loses

    public List<GameObject> objectsToDestroy; // So we can check the object before counting up numObjectsDestroyed

    public BasicButtonController resetButton; // When resetButton is pressed, will reset game

    public void ObjectDestroyed(GameObject objectThatWasDestroyed)
    {
        if (objectsToDestroy.Contains(objectThatWasDestroyed)) // Check that objectThatWasDestroyed is in our list of objectsToDestroy before incrementing numObjectsDestroyed
        {
            numObjectsDestroyed = numObjectsDestroyed + 1; // Can also write: numObjectsDestroyed++; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Fill the bucket (i.e. the instance variable, which starts off empty when declared) with the actual GameManager component in the scene (which is running during gameplay)

        numObjectsToDestroy = objectsToDestroy.Count;

        resetButton.OnButtonPress += ResetGame; // Subscribe the ResetGame() function to the delegate
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining = timeRemaining - Time.deltaTime; // Countdown timer

        if (timeRemaining > 0) // Check if time still remains!
        {
            if (numObjectsDestroyed < numObjectsToDestroy) // If so, we haven't won yet - Game still running
            {
                uiText.text = "Objects Destroyed: " + numObjectsDestroyed
                    + "\nObjects Remaining: " + (numObjectsToDestroy - numObjectsDestroyed)
                    + "\nTime Remaining: " + System.Math.Round(timeRemaining, 2);
            }
            else // We win
            {
                uiText.text = "YOU WIN!!!";
            }
        }
        else // Time is up!
        {
            uiText.text = "Game over man!!";
        }
    }

    void ResetGame()
    {
        timeRemaining = 30f;
    }
}
