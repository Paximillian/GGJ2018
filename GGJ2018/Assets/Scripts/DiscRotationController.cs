using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscRotationController : MonoBehaviour 
{
    public enum ControllerAxis 
    {
        HorizontalAxis1,
        HorizontalAxis2,
        HorizontalAxis3,
        HorizontalAxis4,
    }

    [SerializeField]
    [Range(10,1000)]
    private float m_rotationSpeed;

    [SerializeField]
    private ControllerAxis m_controllerAxis;

    private string m_controllerAxisName;

    private void Awake() 
    {
        m_controllerAxisName = m_controllerAxis.ToString();  
    }
    
    private void Update () 
    {
        transform.Rotate(0, 0, Input.GetAxis(m_controllerAxisName) * m_rotationSpeed * Time.deltaTime * -1);

        //transform.
    }
}
