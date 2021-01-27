﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour

{
    [SerializeField] public Transform m_warpPoint = null;
    [SerializeField, Range(0f, 5f)] float m_warpWaitTime = 3f;
    float m_timer;
    ParticleSystem m_particle = null;

    void Start()
    {
        m_particle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        HumanoidController player = other.gameObject.GetComponent<HumanoidController>();
        if (player)
        {
            if (player.m_pState != HumanoidController.PlayerState.Warping)
            {
                player.m_pState = HumanoidController.PlayerState.Warping;
                m_particle.Play();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_timer += Time.deltaTime;
            Debug.Log(m_timer);

            if (m_timer >= m_warpWaitTime)
            {
                HumanoidController player = other.gameObject.GetComponent<HumanoidController>();
                if (player)
                {
                    other.gameObject.transform.position = m_warpPoint.position;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit.");
        HumanoidController player = other.gameObject.GetComponent<HumanoidController>();
        if (player)
        {
            if (player.m_pState != HumanoidController.PlayerState.Default)
            {
                player.m_pState = HumanoidController.PlayerState.Default;
                m_particle.Stop();
                m_timer = 0;
            }
        }
    }
}
