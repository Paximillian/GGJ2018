using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiscRotationController : MonoBehaviour
{
    public enum RotationAxis 
    {
        RotationAxis1,
        RotationAxis2,
        RotationAxis3,
        RotationAxis4,
    }

    public enum MovementAxis {
        HorizontalAxis1,
        HorizontalAxis2,
        HorizontalAxis3,
        HorizontalAxis4,
        VerticalAxis1,
        VerticalAxis2,
        VerticalAxis3,
        VerticalAxis4,
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
            m_Points = value;

            if (m_MahPointz)
            {
                m_MahPointz.text = string.Format("Player {0}: {1}",
                    int.Parse(m_rotationAxis.ToString().Last().ToString()),
                    m_Points);
            }
        }
    }

    [SerializeField]
    [Range(10, 1000)]
    private float m_rotationSpeed;

    [SerializeField]
    [Range(1, 100)]
    private float m_movementSpeed;

    [SerializeField]
    private RotationAxis m_rotationAxis;

    [SerializeField]
    private MovementAxis m_horizontalAxis;

    [SerializeField]
    private MovementAxis m_verticalAxis;

    [SerializeField]
    private Text m_MahPointz;

    private string m_rotationAxisName;
    private string m_horizontalAxisName;
    private string m_verticalAxisName;

    private void Awake()
    {
        if (int.Parse(name.Last().ToString()) > (MyPrecious.Instance?.NumberOfPlayers ?? 1))
        {
            gameObject.SetActive(false);
        }
        else
        {
            m_rotationAxisName = m_rotationAxis.ToString();
            m_horizontalAxisName = m_horizontalAxis.ToString();
            m_verticalAxisName = m_verticalAxis.ToString();

            if (m_MahPointz)
            {
                m_MahPointz.transform.SetParent(ScoreContainer.Instance.transform);
            }

            Points = 0;
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis(m_rotationAxisName) * m_rotationSpeed * Time.deltaTime);

        transform.Translate(Input.GetAxis(m_horizontalAxisName) * m_movementSpeed * Time.deltaTime,
                            Input.GetAxis(m_verticalAxisName) * m_movementSpeed * Time.deltaTime,
                            0, Space.World);
    }

    private void OnTriggerEnter(Collider oucher)
    {
        RadioWaveController bulleter = oucher.GetComponent<RadioWaveController>();

        if (bulleter)
        {
            if (!bulleter.IzFollowDeWae)
            {
                if ((!bulleter.BoomerOfMe?.Equals(this)) ?? true)
                {
                    Points--;
                    oucher.gameObject.SetActive(false);
                }
            }
        }
    }
}
