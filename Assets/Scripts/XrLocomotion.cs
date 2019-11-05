using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrLocomotion : MonoBehaviour
{
    public string trackpadAxisX, trackpadAxisY; // Need inputs defined for the trackpad/joystick inputs

    public Transform xrRig; // Moving rig, just like in teleport!

    public LayerMask raycastMask; // Define what layers to "sense" floor height

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Record the position on the x and y axis of where the thum is placed on trackpad (or where joystic pushed)
        float trackpadX = Input.GetAxis(trackpadAxisX); //  number representing the amount/speed to move left/right
        float trackpadY = Input.GetAxis(trackpadAxisY); //  number representing the amount/speed to move Forward/back

        // Convert the x and y trackpad values into a direction - essentially how much to move forward/back and how much to move left/right
        Vector3 forward = new Vector3(transform.forward.x, 0f, transform.forward.z) * trackpadX; // forward/back component of 3D motion (Vector3) - along the horizontal plane (do move vertically)
        Vector3 right = new Vector3(transform.right.x, 0f, transform.right.z) * trackpadY; // the direction pointing to the right of the controller 

        // Apply motion now to the rig!
        xrRig.transform.position = xrRig.transform.position + (forward + right) * Time.deltaTime;

        // Terrain-height adjustment:
        float floorHeight = GetFloorHeight(); // Get the floor height
        Vector3 rigPosition = xrRig.position; // Take note of the current rig positon, so we can edit the y-value 
        rigPosition.y = floorHeight; // Change the y-value
        xrRig.transform.position = rigPosition; // Now we have the xrRig position with the y-value updated, so apply it back to the rig's position
    }

    private float GetFloorHeight()
    {
        float floorHeight = 0f; // Will hold the value of the heioght as sensed by raycast

        RaycastHit hitInfo; // Store info about my raycast hit (incliding position -- has height info)
        
        if(Physics.Raycast(Camera.main.transform.position, Vector3.down, out hitInfo, Mathf.Infinity, raycastMask)) // Perform a raycast from my head down to the ground 
        {
            floorHeight = hitInfo.point.y; // Take note of the floor height (height of surface that was hit)
        }

        return floorHeight; // Give this value to the caller 
    }
}
