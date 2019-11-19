using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePaintbrush : MonoBehaviour
{
    public GameObject paintTrailPrefab; // Paint trail prefab will instantiate when we pull the trigger! Paint will follow the brush tip

    private GameObject currentPaintTrail; // The trail that we are currently painting (while trigger is held down)

    private Material paintMaterial; // This is the material that we will paint wheh trigger pulled

    private void Interact() // This function will be called by XR grab when trigger pulled
    {
        if (paintMaterial != null) // Check has paint before painting
        {
            currentPaintTrail = Instantiate(paintTrailPrefab, transform.position, transform.rotation, transform); // Create paint trail that follows the brush!
            currentPaintTrail.GetComponent<Renderer>().material = paintMaterial; // Set the color of the paint trail (i.e. the material)
        }
    }

    private void StopInteract() // When release trigger, stop painting - unparent paint! This function will be called by XR grab when trigger release
    {
        currentPaintTrail.transform.SetParent(null); // Unparent - stop following brush (stops painting)
    }        

    // To detect paint from our pallette, when touched
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paint") // Check that we are in fact touching paint! 
        {
            paintMaterial = collision.gameObject.GetComponent<Renderer>().material; // Get the mat from paint
            gameObject.GetComponent<Renderer>().material = paintMaterial; // Change color of the brush to match paint
        }
    }
}
