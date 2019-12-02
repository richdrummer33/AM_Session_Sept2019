using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneOperator : MonoBehaviour
{
    public Transform m_Lever;
    public Transform m_Crane;

    public float m_Speed;
    public Vector3 m_Direction;

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(m_Lever.eulerAngles.x) > 10f)
        {
            if (m_Lever.eulerAngles.x > 180)
            {
                m_Crane.Translate(-m_Direction * Time.deltaTime * m_Speed);
            }
            else if (m_Lever.eulerAngles.x > 0)
            {
                m_Crane.Translate(m_Direction * Time.deltaTime * m_Speed);
            }
        }
    }
}
