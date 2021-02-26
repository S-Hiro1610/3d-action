using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveController : MonoBehaviour
{
    [SerializeField]GameObject[] m_gbArray = null;
    private void Start()
    {
        //m_gbArray = GameObject.FindGameObjectsWithTag("RightRoad");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var gb in m_gbArray)
            {
                gb.SetActive(true);
            }
        }
    }
}
