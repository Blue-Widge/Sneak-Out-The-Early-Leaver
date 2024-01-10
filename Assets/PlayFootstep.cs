using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayFootstep : MonoBehaviour
{
    public AudioSource m_audiosource;
    
    public Transform m_leftFoot;
    public Transform m_rightFoot;
    Vector3 m_initialL;
    Vector3 m_initialR;
    bool m_leftOnGround = true;
    bool m_rightOnGround = true;
    private void Start()
    {
        if (!m_audiosource)
            m_audiosource = GetComponent<AudioSource>();
        if (!m_audiosource || !m_leftFoot || !m_rightFoot)
            this.enabled = false;
        m_initialL = m_leftFoot.position;
        m_initialR = m_rightFoot.position;
    }

    void Update()
    {
        if (m_initialL.y + 0.2 > m_leftFoot.position.y)
        {
            if (!m_leftOnGround)
            {
                m_audiosource.Play();
            }
            m_leftOnGround = true;
        }
        else
            m_leftOnGround = false;
        if (m_initialR.y + 0.2 > m_rightFoot.position.y)
        {
            if (!m_rightOnGround)
            {
                m_audiosource.Play();
            }
            m_rightOnGround = true;
        }
        else
            m_rightOnGround = false;
    }
}
