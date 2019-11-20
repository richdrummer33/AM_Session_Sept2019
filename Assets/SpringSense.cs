using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringSense : MonoBehaviour
{
    public GameObject button;

    AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == button) // Make sure it's the button touching
        {
            source.Play(); // Play sound
        }
    }
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
