using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.ObjectDestroyed(other.gameObject); // Tally up the objects that contact this collider - take score using the Game Manager

        Destroy(other.gameObject);
    }
}
