using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    public Text uiText; // Reference to my UI text to show fireball hit count

    private int numHits = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paintball")
        {
            numHits++; // Increase this number by 1 (count up)

            uiText.text = "Hits=" + numHits;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = "Hits=" + 0; // Set the default starting text 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
