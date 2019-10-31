using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrTeleport : MonoBehaviour
{
    public Transform xrRig; // Need a reference to my XrRig, since that's what I'm moving!
    public LineRenderer line; // Need reference to line renderer to have it point where I am pointing
    public string teleportButtonName; // Need a button name, so let's make that a public string so we can choose left or right hand

    Vector3 hitPosition; // This will store the last position that was hit by our raycast 
    // Side note: Vector3 declarations initialize to the origin (x,y,z all are 0)

    bool hitIsValid = false; // To let us know if we hit a collider that we can teleport to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, this.transform.position); // We need to define the start point of the line every frame, becuase our hand moves freely

        // We need to "raycast" sense the trajectory of the laser, i.e. where we're pointing
        RaycastHit hit; // This will hold information about what we're pointing at, and the position that is hit by our "laser"

        if (Input.GetButton(teleportButtonName)) // We want this code only to run when pressing the teleport buttion!
        {
            line.enabled = true; // Render our laser! Make visible

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) // Gather information (e.g. "sense" a point/position) on the collider in which we are pointing at -- i.e. perform a raycast 
            {
                // Execute code between these brackets if raycast hits an object (collider)!
                hitPosition = hit.point; // I need to save a record of what is hit 
                line.SetPosition(1, hitPosition); // Set the end of the line (where the laser endS)
                hitIsValid = true;
            }
            else // NEed a condition to handle the case where no collider is hit! Still want to draw laser pointer!
            {
                line.SetPosition(1, transform.forward * 100f); // Cast the laser 100 meters forward
                hitIsValid = false;
            }
        }

        if(Input.GetButtonUp(teleportButtonName)) // If button is released, then lets try teleporting (and disable the laser)
        {
            line.enabled = false; // Disable the laser line

            if(hitIsValid == true) // First check that our raycast did in fact hit a collider! (before teleport)
            {
                Vector3 offsetFix = xrRig.position - Camera.main.transform.position; // Before moving the rig, apply a correction for offset between room center and headset poisition
                offsetFix.y = 0f; // Prevent this offset fix from changing the height of the XrRig.position. SEt the vert component of the offsetFix to 0

                xrRig.position = hitPosition + offsetFix; // Move the rig to the last valid position that we hit with our raycast while we were holding the button
                hitIsValid = false; // Just in case (reset this "flag"
            }
        }
    }
}
