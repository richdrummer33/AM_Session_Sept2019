using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleport : MonoBehaviour
{
    public Transform xrRig;
    private bool hitValid;
    private Vector3 hitPoint;
    
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButton("Left Thumbstick Press"))
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);            

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            { 
                hitValid = true;
                hitPoint = hit.point;
                line.SetPosition(1, hitPoint);
            }
            else
            {
                hitValid = false;
                line.SetPosition(1, transform.position + transform.forward * 100f);
            }
        }

        if (Input.GetButtonUp("Left Thumbstick Press"))
        {
            if (hitValid == true)
            {
                Vector3 playerOffsetFix = xrRig.position - Camera.main.transform.position;
                playerOffsetFix.y = 0f;

                xrRig.position = hitPoint + playerOffsetFix;

                hitValid = false;
            }

            line.enabled = false;
        }
    }
}