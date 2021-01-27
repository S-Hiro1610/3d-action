using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionSwitcher : MonoBehaviour
{
    [SerializeField ] Cinemachine.CinemachineVirtualCameraBase m_vcam = null;
    [SerializeField] Transform m_transformTranslatorSwitcher = null;
    Transform m_temporaryTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player が接触しました" + gameObject.name);
            HumanoidController hc = other.gameObject.GetComponent<HumanoidController>();
            if (hc)
            {
                if (hc.m_transformTranslator)
                {
                    m_temporaryTransform = hc.m_transformTranslator;
                    hc.m_transformTranslator = m_transformTranslatorSwitcher;
                    m_transformTranslatorSwitcher = m_temporaryTransform;
                }
            }
            if (m_vcam)
            {
                m_vcam.MoveToTopOfPrioritySubqueue();
            }
        }
    }
}
