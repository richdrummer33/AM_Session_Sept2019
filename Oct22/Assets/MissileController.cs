using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public GameObject explosionPrefab;

    [SerializeField]
    List<Rigidbody> rbsInRange = new List<Rigidbody>();

    public float explosionForce = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);

        foreach(Rigidbody rb in rbsInRange)
        {
            float dist = Vector3.Distance(transform.position, rb.transform.position); // How far is the object-in-range?

            float normalizedDist = dist / 15f; // Max of 1

            Vector3 forceDirection = (rb.transform.position - transform.position).normalized;

            rb.AddForce(forceDirection * explosionForce * normalizedDist, ForceMode.Impulse);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            rbsInRange.Add(other.GetComponent<Rigidbody>()); // MAke a list of in-range physics objects
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            rbsInRange.Remove(other.GetComponent<Rigidbody>());// Forget out-of-range physics objects
        }
    }


}
