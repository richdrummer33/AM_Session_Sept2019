using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrTeleport : MonoBehaviour
{
    public Transform xrRig; // Need a reference to my XrRig, since that's what I'm moving!
    public LineRenderer line; // Need reference to line renderer to have it point where I am pointing
    public string teleportButtonName; // Need a axis name, so let's make that a public string so we can choose left or right hand

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

        

    }
}
