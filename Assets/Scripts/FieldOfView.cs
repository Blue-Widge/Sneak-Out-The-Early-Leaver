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
    [SerializeField] private bool m_targetDetected = false;
    //In case the entity isn't able 
    [SerializeField] private bool m_canDetectTarget = true;
    //Functions to execute once target detected
    public UnityEvent m_OnTargetDetectedFunctions;
    
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
            m_targetDetected = false;
            return;
        }
        Transform targetTransform = rangeChecks[0].transform;
        Vector3 toTargetDirection = (targetTransform.position - m_eyePosition.position).normalized;
        var angle = Vector3.Angle(transform.forward, toTargetDirection);
        if (angle > (m_viewAngle / 2))
        {
            m_targetDetected = false;
            return;
        }

        float toTargetDistance = Vector3.Distance(m_eyePosition.position, targetTransform.position);
        m_targetDetected = !Physics.Raycast(m_eyePosition.position, toTargetDirection, toTargetDistance, m_obstructionLayerMask);
    }

    private void Update()
    {
        if (!m_targetDetected)
            return;
        Debug.Log("TARGET DETECTED ! ");
        m_OnTargetDetectedFunctions.Invoke();
    }

    IEnumerator FOVRoutine()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return waitingTime;
            if (!m_canDetectTarget)
            {
                m_targetDetected = false;   
                continue;
            }
            DetectTarget();
        }
    }
}
