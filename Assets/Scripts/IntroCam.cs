using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCam : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 1.0f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.linearVelocity = transform.forward * m_Speed;
    }
}
