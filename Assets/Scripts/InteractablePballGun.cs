using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePballGun : InteractableObject
{
    public GameObject paintballPrefab; // Reference to the prefab in our assets folder

    public Transform muzzle; // Reference to the position which the paintball will fire from (instantiate)

    public float fireForce = 100f;

    public override void Interact() // Interact will be a generic name for all interactables (all interactables will have a function with this name)
    {
        base.Interact();

        GameObject newPaintball = Instantiate(paintballPrefab, muzzle.position, muzzle.rotation); // Make a ball at the position of the muzzle (end of barrel)

        newPaintball.GetComponent<Rigidbody>().AddForce(muzzle.forward * fireForce, ForceMode.Impulse); // Fire away (forward)
    }
}