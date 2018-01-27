using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitParticles : Singleton<PlayerHitParticles>
{
    private ParticleSystem m_ParticleSystem;

    protected override void Awake()
    {
        base.Awake();

        m_ParticleSystem = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        m_ParticleSystem.Play();

        StartCoroutine(stopHittingMe());
    }

    private IEnumerator stopHittingMe()
    {
        yield return new WaitForSeconds(0.5f);

        m_ParticleSystem.Stop();
    }
}
