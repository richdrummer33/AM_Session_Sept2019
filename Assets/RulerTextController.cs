using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Place the text object in center of the ruler, and make it face the player
/// </summary>
[ExecuteInEditMode]
public class RulerTextController : MonoBehaviour
{
    public LineRenderer rulerLine; // Need reference to line renderer - need to center (position) this text on the ruler

    public TextMeshPro rulerText; // Update text with measurement (distance) info
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position); // Face the camera

        transform.position = (rulerLine.GetPosition(0) + rulerLine.GetPosition(1)) / 2f; // Center the text on the ruler

        float distance = Vector3.Distance(rulerLine.GetPosition(0), rulerLine.GetPosition(1));

        rulerText.text = System.Math.Round(distance, 2) + " m"; // Need to display disance in meters!
    }
}
