using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    [SerializeField]
    private AudioSource m_SpawnSound;
    [SerializeField]
    private AudioSource m_BumpSound;

    [SerializeField]
    private ParticleSystem m_PlayerHitParticles;

    [SerializeField]
    private AudioSource m_SpinLeft;

    [SerializeField]
    private AudioSource m_SpinRight;

    private string m_rotationAxisName;
    private string m_horizontalAxisName;
    private string m_verticalAxisName;

    public List<PathMakerBetterer> boxOfMakerBetterers = new List<PathMakerBetterer>();

    private GameObject m_DiscModel;

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

    private void OnEnable()
    {
        StartCoroutine(iCanHazDisc());
    }

    private IEnumerator iCanHazDisc()
    {
        while (ObjectPoolManager.Instance == null)
        {
            yield return null;
        }

        GameObject model = ObjectPoolManager.PullObject("Disc");

        if (m_DiscModel != null)
        {
            m_DiscModel.SetActive(false);

            while(m_DiscModel.name.Equals(model.name))
            {
                model.SetActive(false);
                model = ObjectPoolManager.PullObject("Disc");
            }
        }

        m_DiscModel = model;

        m_DiscModel.transform.SetParent(transform);
        m_DiscModel.transform.localPosition = Vector3.zero;

        transform.rotation = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward);

        m_SpawnSound.Play();
    }

    public void makeHurtyBymaster(DiscRotationController hurtymaster, RadioWaveController masterHurtyTool) {

    }

    private void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis(m_rotationAxisName) * m_rotationSpeed * Time.deltaTime);

        if(Input.GetAxis(m_rotationAxisName) > 0)
        {
            if (!m_SpinRight.isPlaying) { m_SpinRight.Play(); }
        }
        else
        {
            m_SpinRight.Stop();
        }

        if (Input.GetAxis(m_rotationAxisName) < 0)
        {
            if (!m_SpinLeft.isPlaying) { m_SpinLeft.Play(); }
        }
        else
        {
            m_SpinLeft.Stop();
        }

        transform.Translate(Input.GetAxis(m_horizontalAxisName) * m_movementSpeed * Time.deltaTime,
                            Input.GetAxis(m_verticalAxisName) * m_movementSpeed * Time.deltaTime,
                            0, Space.World);
    }

    private void OnTriggerEnter(Collider oucher)
    {
        RadioWaveController bulleter = oucher.GetComponent<RadioWaveController>();

        if (bulleter)
        {
            if (!bulleter.IzFollowDeWae && !(bulleter.LastTarget != null && bulleter.LastTarget.holderOfMe == this))
            {
                if ((!bulleter.BoomerOfMe?.Equals(this)) ?? true)
                {
                    m_PlayerHitParticles.Play();
                    Points--;
                    oucher.gameObject.SetActive(false);
                    StartCoroutine(iCanHazDisc());
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_BumpSound.Play();
    }
}
