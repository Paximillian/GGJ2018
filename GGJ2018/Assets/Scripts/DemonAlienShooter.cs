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

                    maybeSpawnSmashBoru();
                }
            }
        }
    }

    private void maybeSpawnSmashBoru()
    {
        if(Random.Range(0, 10) == 9)
        {
            ObjectPoolManager.PullObject("SmashBoru").transform.position = transform.position;
        }
    }
}
