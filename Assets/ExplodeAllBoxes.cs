using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAllBoxes : MonoBehaviour
{
    public Transform terrain;

    private void OnTriggerEnter(Collider other) // HAnd touches this cheat button
    {
        // Iterate through all the objects in the list of cubesToDestroy
                
        foreach(GameObject cube in GameManager.instance.cubesToDestroy)
        {
            Vector3 forceDirection = (cube.transform.position - terrain.position).normalized;

            cube.GetComponent<Rigidbody>().AddForce(forceDirection * 15f, ForceMode.Impulse);

            Debug.Log("Cube " + cube.name + " has been launched");
        }
        
        List<GameObject> cubesToDestroy = GameManager.instance.cubesToDestroy;

        for (int i = 0; i < cubesToDestroy.Count; i++)
        {
            cubesToDestroy[i].GetComponent<Rigidbody>().AddForce(Vector3.left * 15f, ForceMode.Impulse);

            Debug.Log("Cube " + cubesToDestroy[i].name + " has been launched");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
