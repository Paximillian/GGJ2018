using System;
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

    private void OnTriggerEnter(Collider oucher)
    {
        if (oucher.gameObject.layer == LayerMask.NameToLayer("Bulleter"))
        {
            RadioWaveController bulleter = oucher.GetComponent<RadioWaveController>();
            if (!bulleter.IsDirected)
            {
                if (bulleter.LastLauncher)
                {
                    bulleter.LastLauncher.Points++;
                    oucher.gameObject.SetActive(false);
                }
            }
        }
    }
}
