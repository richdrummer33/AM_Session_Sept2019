using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BasicButtonController : MonoBehaviour
{
    public Transform pressedPosition; // Where to move when pressed

    public Transform button; // The renderer for the button (which will move)

    Vector3 startPosition; 
    
    void Start()
    {
        startPosition = button.position; // Take note of the button posn @ game start (before pressed!)
    }

    private void OnTriggerEnter(Collider other) // Button was touched!
    {
        button.position = pressedPosition.position; // Move button to pressed (closed) position! 
    }

    private void OnTriggerExit(Collider other)
    {
        button.position = startPosition; // Return to orig posn (open button)
    }
}
