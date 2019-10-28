using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    public GameObject m_CollidingObject;
    public GameObject m_HeldObject;

    public Animator m_animator; // This is a reference to the animator component on the sim hand

    //XR-specific variables
    public string gripInputName; // Name of the grip thjat I set up in the Project Settings Inputs list

    private bool gripHeld; 

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            m_CollidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_CollidingObject = null;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(gripInputName) > 0.5f && gripHeld == false) // Grab
        {
            //m_animator.SetBool("Close Hand", true); // Changes the parameter in the Animator

            if (m_CollidingObject)
            {
                Grab();
            }

            gripHeld = true; // Prevent from running this code (e.g. m_animator.SetBool("Close Hand", true) and Grab()) every frame (e.g. 90x per sec)
        }
        else if (Input.GetAxis(gripInputName) < 0.5f && gripHeld == true) // Release
        {
            //m_animator.SetBool("Close Hand", false); // Changes the parameter in the Animator

            if (m_HeldObject)
            {
                Release();
            }

            gripHeld = false; // No longer holding the grip, so only let this code in "else if" statement run once upon release of grip
        }
    }

    void Grab()
    {
        m_HeldObject = m_CollidingObject;
        m_HeldObject.GetComponent<Rigidbody>().isKinematic = true;
        m_HeldObject.transform.SetParent(transform);
    }

    void Release()
    {
        m_HeldObject.transform.SetParent(null);
        m_HeldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_HeldObject = null;
    }
}
