using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BasicButtonController : MonoBehaviour
{
    public Transform pressedPosition; // Where to move when pressed

    public Transform button; // The renderer for the button (which will move)

    Vector3 startPosition;

    AudioSource source; // AudioSouce connected to this gameobject

    public delegate void ButtonPushEvent(); // Defining the delegate (not* an instance)
    public ButtonPushEvent OnButtonPush; // Creating a instance of the delegate

    // Other scripts can "subscribe" functions to the OnButtonPush delegate
    // When OnButtonPush() is called, all functions that are "subscribed" to OnButtonPush, will be run

    void Start()
    {
        startPosition = button.position; // Take note of the button posn @ game start (before pressed!)

        source = GetComponent<AudioSource>(); // Get the source attached to this game object
    }

    private void OnTriggerEnter(Collider other) // Button was touched!
    {
        button.position = pressedPosition.position; // Move button to pressed (closed) position! 

        source.Play(); // Play a sound

        OnButtonPush(); // Runs all functions subscribed to this button
    }

    private void OnTriggerExit(Collider other)
    {
        button.position = startPosition; // Return to orig posn (open button)
    }
}
