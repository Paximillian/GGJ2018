using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiscRotationController : MonoBehaviour
{
    public enum ControllerAxis
    {
        HorizontalAxis1,
        HorizontalAxis2,
        HorizontalAxis3,
        HorizontalAxis4,
    }

    private int m_Points;
    public int Points
    {
        get
        {
            return m_Points;
        }
        set
        {
            m_MahPointz.text = string.Format("Player {0}: {1}", 
                int.Parse(m_controllerAxis.ToString().Last().ToString()),
                m_Points = value);
        }
    }

    [SerializeField]
    [Range(10, 1000)]
    private float m_rotationSpeed;

    [SerializeField]
    private ControllerAxis m_controllerAxis;

    [SerializeField]
    private Text m_MahPointz;

    private string m_controllerAxisName;

    private void Awake()
    {
        m_controllerAxisName = m_controllerAxis.ToString();

        m_MahPointz.transform.SetParent(ScoreContainer.Instance.transform);

        Points = 0;
    }

    private void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis(m_controllerAxisName) * m_rotationSpeed * Time.deltaTime * -1);

        //transform.
    }

    private void OnTriggerEnter(Collider oucher)
    {
        if(oucher.gameObject.layer == LayerMask.NameToLayer("Bulleter"))
        {
            Points--;
            oucher.gameObject.SetActive(false);
        }
    }
}
