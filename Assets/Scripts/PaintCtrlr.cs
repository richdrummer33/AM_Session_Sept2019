using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PaintCtrlr : MonoBehaviour
{
    public GameObject paintPrefab; // Your 3d model or whatever! Maybe particles? To intantiate

    private GameObject currentPaintTrail; // This will hold a reference to the object that we created (Note: it's null by default)

    public Transform paintInstantiationLocation; 

    void Update()
    {
        if (Input.touchCount > 0) // Check that player is touching screen, before attemptint to instantiate object
        {
            if (currentPaintTrail == null) // If we haven't yet instantiated the prefab, then do so
            {
                currentPaintTrail = Instantiate(paintPrefab, paintInstantiationLocation.position, paintPrefab.transform.rotation); // Create prefab at the postition first hit by the raycast, with the default prefab rotation
                currentPaintTrail.transform.SetParent(paintInstantiationLocation);
            }
        }
        else // If stop touching screen, let's enable the ability to create a new ruler instance
        {
            currentPaintTrail.transform.SetParent(null);
            currentPaintTrail = null;
        }
    }
}