using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// "Remember" the start position and can reset the position at any time
/// </summary>
public class CubeController : MonoBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;

    public BasicButtonController resetButton; // The button with the delegate
    
    void Start()
    {
        startPosition = transform.position; // Remember pos!
        startRotation = transform.rotation; // Remember rot! For when we want to reset position/rotation

        resetButton.OnButtonPush += ResetPosition;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        GetComponent<MeshRenderer>().enabled = true; // Make invisible instead of destroying!
    }
}