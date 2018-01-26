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
        insides = new BulleterFasterer();
        m_SplodingParticles.Play();
    }
}
