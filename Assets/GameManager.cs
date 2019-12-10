using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int numObjectsDestroyed = 0; // Tally (score)
    int numObjectsToWin; // Number to destroy in order to win

    public List<GameObject> cubesToDestroy = new List<GameObject>(); // To hold/reference the cubes/objects that count for score

    public Text uiText;

    public static GameManager instance; // Singelton - static means that "instance" belongs to the class GameManager itself 

    public float timeRemaining = 30; // number of seconds remaining

    public BasicButtonController resetGameButton;

    void Start()
    {
        instance = this;

        numObjectsToWin = cubesToDestroy.Count; // Number of cubes in the list

        resetGameButton.OnButtonPush += ResetTimer; // Subscribe the ResetTimer function to my delegate
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime; // Real-time countdown timer

        if (timeRemaining > 0) // Keep on playing
        {
            if (numObjectsDestroyed < numObjectsToWin)
            {
                uiText.text = "Objects Destroyed: " + numObjectsDestroyed
                    + "\nObjects Remaining " + (numObjectsToWin - numObjectsDestroyed)
                    + "\nTime Remaining " + timeRemaining;
            }
            else
            {
                uiText.text = "YOU WIN!!";
            }
        }
        else // Lose!
        {
            uiText.text = "GAME OVER!!";
        }

    }

    public void ObjectDestroyed(GameObject objectThatWasDestroyed)
    {
        if (cubesToDestroy.Contains(objectThatWasDestroyed)) // Check if is in our list before taking score
        {
            numObjectsDestroyed = numObjectsDestroyed + 1; // Increment the count
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 30f;
    }
}
