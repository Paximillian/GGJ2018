using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoundaries : MonoBehaviour
{
    private void OnTriggerEnter(Collider oucher)
    {
        oucher.gameObject.SetActive(false);
    }
}
