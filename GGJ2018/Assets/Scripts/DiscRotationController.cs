using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscRotationController : MonoBehaviour 
{
    [SerializeField]
    [Range(10,1000)]
    private float m_rotationSpeed;

    // Update is called once per frame
    private void Update () 
    {
        float axis = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * m_rotationSpeed * Time.deltaTime * -1);
    }
}
