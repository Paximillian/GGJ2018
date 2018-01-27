using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuffDaPuff : Singleton<HuffDaPuff>
{
    private ParticleSystem pooder;

    protected override void Awake()
    {
        pooder = GetComponent<ParticleSystem>();
    }

    public void Show(Vector3 position)
    {
        transform.position = position;
        pooder.Play();
    }
}
