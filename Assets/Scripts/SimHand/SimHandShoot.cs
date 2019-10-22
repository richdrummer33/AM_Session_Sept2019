using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandShoot : MonoBehaviour
{
    public GameObject m_prefabPaintbal;
    public float m_shootForce = 1500.0f;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject tempPaintball = Instantiate(m_prefabPaintbal, transform.position, transform.rotation);
            tempPaintball.GetComponent<Rigidbody>().AddForce(transform.forward * m_shootForce);
            Destroy(tempPaintball, 3.0f);
        }
    }
}
