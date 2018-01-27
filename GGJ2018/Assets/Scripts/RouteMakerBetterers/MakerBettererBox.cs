using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerBettererBox : RadioWaveController
{
    public PathMakerBetterer insides;

    [SerializeField]
    private ParticleSystem m_SplodingParticles;

    private void OnEnable()
    {
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
    }
}
