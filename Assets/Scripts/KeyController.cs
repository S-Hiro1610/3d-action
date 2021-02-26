using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] AudioClip m_se = null;
    AudioSource m_audio;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }
    // Player が接触したら音を鳴らしてこのオブジェクトを消す
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_audio.PlayOneShot(m_se);
            Destroy(this.gameObject);
        }
    }
}
