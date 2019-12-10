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

    public string triggerInputName; // NAme of right or left trigger input as per Inputs setup
    private bool triggerPulled; // Make sure that we interact only once per trigger-pull

    FixedJoint grabJoint; // Joint btwn hand and held object

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
            m_animator.SetBool("Close Hand", true); // Changes the parameter in the Animator
            
            if (m_CollidingObject)
            {
                Grab();
            }

            gripHeld = true; // Prevent from running this code (e.g. m_animator.SetBool("Close Hand", true) and Grab()) every frame (e.g. 90x per sec)
        }
        else if (Input.GetAxis(gripInputName) < 0.5f && gripHeld == true) // Release
        {
            m_animator.SetBool("Close Hand", false); // Changes the parameter in the Animator

            if (m_HeldObject)
            {
                Release();
            }

            gripHeld = false; // No longer holding the grip, so only let this code in "else if" statement run once upon release of grip
        }

        // Monitor trigger pull - interact when pulled > 50%
        if(Input.GetAxis(triggerInputName) > 0.5f && triggerPulled == false)
        {
            // Code to interact - paint or shoot paintball gun or start the electric drill
            if (m_HeldObject != null) // First check we holding obj to interact with
            {
                // m_HeldObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // Attempt interact - if held obj has function with name "Interact", it will run

                InteractableObject interactable = m_HeldObject.GetComponent<InteractableObject>(); // Attempts to get InteractableObject from held object

                if(interactable != null)
                {
                    interactable.Interact(); // Runs the overriden Interact() function on the object we are holding. Replaces sendmessage function
                }
            }

            triggerPulled = true; // PRevent repeated interact while holding trigger
        }
        else if (Input.GetAxis(triggerInputName) < 0.5f && triggerPulled == true)
        {
            // Attempt stop interact
            if(m_HeldObject != null)
            {
                // m_HeldObject.SendMessage("StopInteract", SendMessageOptions.DontRequireReceiver); // Attempt interact - if held obj has function with name "StopInteract", it will run

                InteractableObject interactable = m_HeldObject.GetComponent<InteractableObject>();

                if(interactable != null) // In fact this is an interactable object
                {
                    interactable.StopInteract(); // Runs the overriden StopInteract() function on the object we are holding. Replaces sendmessage function
                }
            }

            triggerPulled = false; 
        }
    }


    void Grab()
    {
        m_HeldObject = m_CollidingObject;

        grabJoint = gameObject.AddComponent<FixedJoint>(); // Create the joint component on the hand

        grabJoint.connectedBody = m_HeldObject.GetComponent<Rigidbody>(); // Define connected body (held obj)

        grabJoint.breakForce = 1000f; // Amt force reqrd to break the joint (obj falls to ground on break)

        grabJoint.breakTorque = 1000f;

        /// Old parenting approach
        //m_HeldObject.GetComponent<Rigidbody>().isKinematic = true;
        //m_HeldObject.transform.SetParent(transform);
    }

    void Release()
    {
        Destroy(grabJoint); // Drop object!

        /// Old parenting approach
        //m_HeldObject.transform.SetParent(null);
        //m_HeldObject.GetComponent<Rigidbody>().isKinematic = false;

        m_HeldObject = null; // "Forget" it since we dropped it
    }
}
