using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Shooting : MonoBehaviour
{
    public ParticleSystem Particle_System;
    public AudioSource audioSource;
    public LayerMask layerMask;

    public void PlayGunParticles()
    {
        if (Particle_System != null)
        {
            Particle_System.Play();
        }

        Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, layerMask);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }

    }   
}
