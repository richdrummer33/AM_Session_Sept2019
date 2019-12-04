using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    ParticleSystem explodeParticles;
    
    void Start()
    {
        explodeParticles = GetComponentInChildren<ParticleSystem>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        explodeParticles.Play();
    }
}
