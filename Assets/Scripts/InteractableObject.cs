using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interaction started!");

        // Add more code if I want (maybe make a "pick-up/click" sound)
    }

    public virtual void StopInteract()
    {
        Debug.Log("Interaction stopped!");

        // Add more code if I want (maybe make a "drop" sound)
    }
}
