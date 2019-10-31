using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrLocomotion : MonoBehaviour
{
    public string trackpadAxisX, trackpadAxisY; // Need inputs defined for the trackpad/joystick inputs

    public Transform xrRig; // Moving rig, just like in teleport!

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
    }
}
