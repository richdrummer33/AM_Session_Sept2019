using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballController : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5f); // Paintball disappear in 5 seconds
    }

    private void OnCollisionEnter(Collision otherCollider) // ***Non-trigger*** collider on this painball must be used
    {
        if (otherCollider.gameObject.GetComponent<Renderer>()) // Make sure that the object we hit is not just a lone (invisible) collider, but a gameboject with a renderer!
        {
            otherCollider.gameObject.GetComponent<Renderer>().material = this.gameObject.GetComponent<Renderer>().material; // Apply the paintball's material (color) to the thing that it hit
        }

        Destroy(this.gameObject); // Now this paintball exists no longer
    }
}
