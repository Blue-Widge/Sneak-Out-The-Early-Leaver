using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FieldOfView : MonoBehaviour
{
    //GameObject of the entity
    public GameObject m_gameObject;
    //Position of the eyes for the fov
    public Transform m_eyePosition;
    //Layer that represents the targets that can be detected
    public LayerMask m_targetLayerMask;
    //Layer that represents the obstacles for the vision
    public LayerMask m_obstructionLayerMask;
    //Angle of view
    [Range(0f, 360f)]
    public float m_viewAngle;
    //Radius of detection
    public float m_viewRadius;
    //Serialized bool to see in the editor if the target is detected
    [FormerlySerializedAs("m_targetDetected")]
    [SerializeField] private bool m_hasDetectedTarget = false;
    //In case the entity isn't able 
    [SerializeField] private bool m_canDetectTarget = true;
    //Contain the transform of the detected target
    Transform m_detectedTarget;
    private void Start()
    {
        if (!m_gameObject)
            m_gameObject = this.gameObject;
        if (!m_eyePosition)
            m_eyePosition = this.transform;
        StartCoroutine(FOVRoutine());
    }

    private void DetectTarget()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(m_eyePosition.position, m_viewRadius, m_targetLayerMask);
        if (rangeChecks.Length == 0)
        {
            m_hasDetectedTarget = false;
            return;
        }
        Debug.Log("Target is in range");
        m_detectedTarget = rangeChecks[0].transform;
        Vector3 toTargetDirection = (m_detectedTarget.position - m_eyePosition.position).normalized;
        var angle = Vector3.Angle(transform.forward, toTargetDirection);
        if (angle > (m_viewAngle / 2))
        {
            m_hasDetectedTarget = false;
            return;
        }
        Debug.Log("Target is in angle");
        
        float toTargetDistance = Vector3.Distance(m_eyePosition.position, m_detectedTarget.position);
        m_hasDetectedTarget = !Physics.Raycast(m_eyePosition.position, toTargetDirection, toTargetDistance, m_obstructionLayerMask);
    }

    private void Update()
    {
        if (!m_hasDetectedTarget)
            return;
        Debug.Log("TARGET DETECTED ! ");
        this.GetComponent<PlayerDetected>().OnPlayerDetected(m_detectedTarget);
    }

    IEnumerator FOVRoutine()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return waitingTime;
            if (!m_canDetectTarget)
            {
                m_hasDetectedTarget = false;   
                continue;
            }
            DetectTarget();
        }
    }
}
