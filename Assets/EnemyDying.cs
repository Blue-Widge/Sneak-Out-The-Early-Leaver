using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyDying : MonoBehaviour
{
    public Animator m_animator;

    void Start()
    {
        if (!m_animator)
            m_animator = GetComponentInChildren<Animator>();
    }

    public void OnDying()
    {
        if (!m_animator)
        {
            Destroy(gameObject);
            return;
        }
        m_animator.SetBool("IsShot", true);
        var navMesh = gameObject.GetComponentInChildren<NavMeshAgent>();
        if (navMesh)
        {
            navMesh.speed = 0.0f;
            navMesh.enabled = false;
        }
        var fieldOfView = gameObject.GetComponentInChildren<FieldOfView>();
        if (fieldOfView)
            fieldOfView.enabled = false;
    }
}
