using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DemonAlienShooter : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float secondsBetweenShoostings = 1;

    [SerializeField]
    private AudioSource m_RustySpawnSound;

    [SerializeField]
    private AudioSource[] m_RustyHitSound;

    [SerializeField]
    private ParticleSystem m_RustyHitParticles;

    [SerializeField]
    private GameObject RustySpoon;
    
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(shootDemBulletz());
    }

    private IEnumerator shootDemBulletz()
    {
        for(;;)
        {
            yield return new WaitForSeconds(secondsBetweenShoostings);

            fireInDaHole();
        }
    }

    private void fireInDaHole()
    {
        RadioWaveController bullet = ObjectPoolManager.PullObject("Bullet").GetComponent<RadioWaveController>();
        bullet.transform.position = RustySpoon.transform.position;
        StartCoroutine(SpinRustySpin(bullet));
        m_RustySpawnSound.Play();
        m_Animator.SetTrigger("shoot");
    }

    private IEnumerator SpinRustySpin(RadioWaveController bullet) {
        yield return new WaitForEndOfFrame();

        this.transform.up = -bullet.movedir;
    }

    private void OnTriggerEnter(Collider oucher)
    {
        if (oucher.gameObject.layer == LayerMask.NameToLayer("Bulleter"))
        {
            RadioWaveController bulleter = oucher.GetComponent<RadioWaveController>();
            if (!bulleter.IzFollowDeWae)
            {
                if (bulleter.BoomerOfMe)
                {
                    bulleter.BoomerOfMe.Points += 5;
                    oucher.gameObject.SetActive(false);
                    m_RustyHitSound[Random.Range(0, m_RustyHitSound.Length)].Play();
                    m_RustyHitParticles.gameObject.SetActive(true);
                    m_RustyHitParticles.transform.position = bulleter.transform.position;
                    m_RustyHitParticles.Play();
                    m_Animator.SetTrigger("hit");

                    StartCoroutine(stopHittingMe());

                    maybeSpawnSmashBoru();
                }
            }
        }
    }

    private IEnumerator stopHittingMe()
    {
        yield return new WaitForSeconds(0.5f);

        m_RustyHitParticles.gameObject.SetActive(false);
    }

    private void maybeSpawnSmashBoru()
    {
        if(Random.Range(0, 10) < 2)
        {
            ObjectPoolManager.PullObject("SmashBoru").transform.position = transform.position;
        }
    }
}
