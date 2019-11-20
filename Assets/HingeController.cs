using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Track how far the lever is pushed/pulled
/// </summary>
public class HingeController : MonoBehaviour
{
    HingeJoint joint; // Need reference to joint to access the current angle

    float angleLimit;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();

        angleLimit = joint.limits.max; // Take note of angle limit for normalization
    }

    // Calculate percentage that lever is pulled/pushed (value between -1 and +1)
    public float NormalizedControlValue() // This function can be accessed by other scripts on other game objects to perform actions, like moving 
    {
        float normValue = joint.angle / angleLimit; // Normalization 

        return normValue; 
    }
}
