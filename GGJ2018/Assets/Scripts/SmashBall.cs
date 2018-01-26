using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBall : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time)) * Time.deltaTime;
    }
}
