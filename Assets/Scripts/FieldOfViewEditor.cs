using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.m_eyePosition.position, Vector3.up, Vector3.forward, 360, fov.m_viewRadius);
        Vector3 viewAngle01 = LookingDirection(fov.m_eyePosition.eulerAngles.y, -fov.m_viewAngle / 2);
        Vector3 viewAngle02 = LookingDirection(fov.m_eyePosition.eulerAngles.y, fov.m_viewAngle / 2);
        Handles.color = Color.yellow;
        Handles.DrawLine(fov.m_eyePosition.position, fov.m_eyePosition.position + viewAngle01 * fov.m_viewRadius);
        Handles.DrawLine(fov.m_eyePosition.position, fov.m_eyePosition.position + viewAngle02 * fov.m_viewRadius);
    }

    private Vector3 LookingDirection(float p_eulerY, float p_viewAngle)
    {
        p_viewAngle += p_eulerY;
        return new Vector3(Mathf.Sin(p_viewAngle * Mathf.Deg2Rad), 0, Mathf.Cos(p_viewAngle * Mathf.Deg2Rad));
    }
}
