using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] float m_Xamplitude = 1f;
    [SerializeField] float m_Yamplitude = 1f;
    [SerializeField] float m_timeSpeed = 1f;
    [SerializeField] Transform m_transformTranslater = null;
    Vector3 m_intialPos;

    void Start()
    {
        m_intialPos = this.transform.position;
    }

    void Update()
    {
        //this.transform.position = m_intialPos + m_amplitude * Mathf.Sin(m_timeSpeed * Time.time) * Vector3.right;

        this.transform.position = m_intialPos + m_Xamplitude * Mathf.Sin(m_timeSpeed * Time.time) * this.transform.right + m_Yamplitude * Mathf.Cos(m_timeSpeed * Time.time) * this.transform.up;
    }
}