using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBaddies : MonoBehaviour
{
    public GameObject m_prefabPaintball;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(m_prefabPaintball, transform.position + transform.up, Quaternion.identity);
    }
}
