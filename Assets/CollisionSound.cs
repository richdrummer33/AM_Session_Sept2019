using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1f) // Checking if the velocity of collision is greater than 1m/s
        {
            // Using relativeVelocity to set the volume
            source.volume = Mathf.Clamp(collision.relativeVelocity.magnitude * 0.25f, 0f, 1f); // Clamp ensures that the value does not exceed some min and max

            source.pitch = Mathf.Clamp(collision.relativeVelocity.magnitude * 0.25f, 0f, 1f); // = Random.Range(0f, 1f);

            Debug.Log("Relative velocity " + collision.relativeVelocity.magnitude);

            source.Play();
        }
    }
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
}
