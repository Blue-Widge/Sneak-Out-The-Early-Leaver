using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using Vector3 = UnityEngine.Vector3;

public class PlayerDetected : MonoBehaviour
{
    public Animator m_enemyAnimator;
    public NavMeshAgent m_navMeshAgent;
    public AudioSource m_audioSource;
    private void Start()
    {
        if (!m_enemyAnimator)
            this.transform.parent.GetComponentInChildren<Animator>();
        if (!m_navMeshAgent)
            this.transform.parent.GetComponentInChildren<NavMeshAgent>();
        if (!m_audioSource)
            this.transform.parent.GetComponentInChildren<AudioSource>();
    }

    public void OnPlayerDetected(Transform p_playerTransform)
    {
        if (m_enemyAnimator)
            m_enemyAnimator.SetBool("PlayerDetected", true);
        if (m_navMeshAgent)
        {
            m_navMeshAgent.speed = 0.0f;
            m_navMeshAgent.enabled = false;
            this.GetComponentInChildren<FieldOfView>().enabled = false;
        }
        if (m_audioSource)
            m_audioSource.Play();   
        var playerPos = p_playerTransform.position;
        this.transform.Rotate(Vector3.up, -Vector3.Angle((playerPos - this.transform.position).normalized, playerPos));
        StartCoroutine(FadeInScene());
    }

    IEnumerator FadeInScene()
    {
        TunnelingVignetteController vignette = Camera.main.GetComponentInChildren<TunnelingVignetteController>();
        /*if (vignette)
        {
            while (vignette.currentParameters.apertureSize > 0)
            {
                vignette.currentParameters.apertureSize -= Time.deltaTime / 2f;
                yield return null;
            }
        }
        else
            yield return new WaitForSeconds(2f);
        */
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
