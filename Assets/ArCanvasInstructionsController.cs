using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArCanvasInstructionsController : MonoBehaviour
{
    public List<GameObject> steps = new List<GameObject>(); // Need a list of the steps for this instruction set

    int currentStep = 0; // Record of what step we're on

    public GameObject taskSelectionCanvas; // So we can enable/disable it

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
            taskSelectionCanvas.SetActive(true); // Allow user to select a new set of tasks to step through - we're done with these!

            currentStep = 0; // Just in case!

            gameObject.SetActive(false); // We're done with these steps, so disable
        }
    }
}
