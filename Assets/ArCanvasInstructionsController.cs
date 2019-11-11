using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArCanvasInstructionsController : MonoBehaviour
{
    public List<GameObject> steps = new List<GameObject>(); // Need a list of the steps for this instruction set

    int currentStep = 0; // Record of what step we're on

    public GameObject taskSelectionCanvas;

    public void OnEnable() // This is called automatically when this gameobject is enabled (Monobehavior funciton)
    {
        currentStep = 0; // Ensure we start at the 1st step!

        steps[currentStep].SetActive(true); // Enable first step

        taskSelectionCanvas.SetActive(false); // Disable task sel buttons while running the task steps
    }

    // Can be called from the "Next Step" button to move to next step
    public void NextStep()
    {
        steps[currentStep].SetActive(false); // Disable step that we just finished

        currentStep = currentStep + 1; // Increment the index 

        if(currentStep < steps.Count) // If we haven't reached the end of the lsit of steps, enable next step
        {
            steps[currentStep].SetActive(true); // Enable the next step
        }
        else // Reset app to main menu (task selection canvas)
        {
            // *************** COVER THIS *************************
            taskSelectionCanvas.SetActive(true); // COVER THIS *************************

            currentStep = 0; // reset!

            gameObject.SetActive(false);
        }
    }
}
