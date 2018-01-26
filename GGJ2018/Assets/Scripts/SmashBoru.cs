using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmashBoru : MonoBehaviour
{
    private float m_Speed = 2f;
    private float m_SinSign = 1;
    private float m_CosSign = 1;

    private void Awake()
    {
        StartCoroutine(swapper());
    }

    private IEnumerator swapper()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));

            while (Mathf.Abs(Mathf.Cos(Time.time)) < 0.1f)
            {
                yield return null;
            }

            m_SinSign = Mathf.Sign(Random.Range(-1f, 1f));
            m_CosSign = Mathf.Sign(Random.Range(-1f, 1f));
        }
    }

    private void Update()
    {
        transform.position += new Vector3(Mathf.Cos(Time.time) * m_CosSign, Mathf.Sin(1 - Time.time) * m_SinSign) * m_Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerBoundary"))
        {
            m_SinSign *= -1;
            m_CosSign *= -1;
        }
    }

    private void OnTriggerEnter(Collider oucher)
    {
        RadioWaveController bulleter = oucher.GetComponent<RadioWaveController>();

        if (bulleter)
        {
            if (bulleter.BoomerOfMe)
            {
                MakerBettererBox betterer = ObjectPoolManager.PullObject("Buffer").GetComponent<MakerBettererBox>();
                betterer.transform.position = transform.position;
                betterer.SetWaypoint(bulleter.LastTarget, null);
                gameObject.SetActive(false);
                oucher.gameObject.SetActive(false);
            }
        }
    }
}
