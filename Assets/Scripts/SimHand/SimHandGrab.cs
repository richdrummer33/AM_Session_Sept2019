using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject m_CollidingObject;
    public GameObject m_HeldObject;

    public Animator m_animator; // This is a reference to the animator component on the sim hand

    FixedJoint grabJoint; // Joint btwn hand and held object

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            m_CollidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_CollidingObject = null;
    }

    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) // Grab
        {
            m_animator.SetBool("Close Hand", true); // Changes the parameter in the Animator
                       
            if (m_CollidingObject)
            {
                Grab();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1)) // Release
        {
            m_animator.SetBool("Close Hand", false); // Changes the parameter in the Animator

            if (m_HeldObject)
            {
                Release();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(prefab, transform.position + transform.up * 0.5f, Quaternion.identity);
        }
    }

    void Grab()
    {
        m_HeldObject = m_CollidingObject;

        grabJoint = gameObject.AddComponent<FixedJoint>(); // Create the joint component on the hand

        grabJoint.connectedBody = m_HeldObject.GetComponent<Rigidbody>(); // Define connected body (held obj)

        grabJoint.breakForce = 1000f; // Amt force reqrd to break the joint (obj falls to ground on break)

        grabJoint.breakTorque = 1000f;
    }

    void Release()
    {
        Destroy(grabJoint); // Drop object!

        m_HeldObject = null;
    }
}
