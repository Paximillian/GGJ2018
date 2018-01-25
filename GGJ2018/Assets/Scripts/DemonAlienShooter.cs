﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAlienShooter : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float secondsBetweenShoostings = 1;

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
        bullet.transform.position = transform.position;
    }
}
