using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MakerBettererBox : RadioWaveController
{
    public PathMakerBetterer insides;

    [SerializeField]
    private ParticleSystem m_SplodingParticles;

    [SerializeField]
    private ParticleSystem m_PowderParticles;

    private void OnEnable()
    {
        m_PowderParticles?.Stop();

        int numberOfBetererer = Random.Range(0, 3);
        switch (numberOfBetererer) {
            case 0:
                insides = new BulleterFasterer();
                break;
            case 1:
                insides = new WaeSlowerer();
                break;
            case 2:
                insides = new OuchiererMorrerer();
                break;
            default:
                break;
        }

        m_SplodingParticles.Play();
        StartCoroutine(huffDaPuff());
    }

    private IEnumerator huffDaPuff()
    {
        yield return new WaitForSeconds(1.5f);
        m_PowderParticles.Play();
    }
}
