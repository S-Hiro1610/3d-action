using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DirectionSwitcher : MonoBehaviour
{
    [SerializeField ] CinemachineVirtualCamera m_vcam = null;
    [SerializeField] Transform m_transformTranslatorSwitcher = null;
    Transform m_temporaryTransform;
    GameObject m_player = null;

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        RefreshCameraFollowOffset();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            m_player = other.gameObject;
            Debug.Log("Player が接触しました" + gameObject.name);
            m_player.transform.forward = m_transformTranslatorSwitcher.right;
            RefreshCameraFollowOffset();

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


        }
    }

    void RefreshCameraFollowOffset()
    {
        if (m_vcam)
        {
            var nextvcam = Instantiate(m_vcam);

            //m_vcam.MoveToTopOfPrioritySubqueue();
            //var transposer = m_vcam.GetCinemachineComponent<CinemachineTransposer>();
            //transposer.m_FollowOffset = m_player.transform.TransformDirection(Vector3.right * 10f + Vector3.up * 2f);

            var transposer = nextvcam.GetCinemachineComponent<CinemachineTransposer>();
            transposer.m_FollowOffset = m_player.transform.TransformDirection(Vector3.right * 10f + Vector3.up * 2f);
            nextvcam.MoveToTopOfPrioritySubqueue();
        }
    }
}
