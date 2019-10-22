using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject m_CollidingObject;
    public GameObject m_HeldObject;

    public Animator m_animator; // This is a reference to the animator component on the sim hand

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
