using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCatcher : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
        if (collision.gameObject.CompareTag("wave"))
        {
            Debug.Log("Hi");

            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }
}
