using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiscRotationController : MonoBehaviour
{
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
                    myPlayerNumber,
                    m_Points);
            }
        }
    }

    public int MyPlayerNumber
    {
        get
        {
            return myPlayerNumber;
        }
    }

    [SerializeField]
    private int m_Death;
    public int PointsToDie { get { return m_Death; } }

    [SerializeField]
    [Range(10, 1000)]
    private float m_rotationSpeed;

    [SerializeField]
    [Range(1, 100)]
    private float m_movementSpeed;
    
    [SerializeField]
    private Text m_MahPointz;

    [SerializeField]
    private AudioSource m_SpawnSound;
    [SerializeField]
    private AudioSource m_BumpSound;

    [SerializeField]
    private AudioSource m_SpinLeft;

    [SerializeField]
    private AudioSource m_SpinRight;




    public List<PathMakerBetterer> boxOfMakerBetterers = new List<PathMakerBetterer>();

    private GameObject m_DiscModel;

    private IDiscController m_discInputController;

    private static int playerNumberTracker = 0;
    
    private int myPlayerNumber;

    private void Awake()
    {
        if (int.Parse(name.Last().ToString()) > (MyPrecious.Instance?.NumberOfPlayers ?? 1))
        {
            gameObject.SetActive(false);
        }
        else
        {
            myPlayerNumber = ++playerNumberTracker;
            m_discInputController = MyPrecious.Instance.JoinedControllers[myPlayerNumber];

            Debug.Log(m_discInputController);

            if (m_MahPointz)
            {
                m_MahPointz.transform.SetParent(ScoreContainer.Instance.transform);
            }

            MyPrecious.Instance.playersThatAreAlive.Add(this);

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
        float rotationAxisVal = m_discInputController.GetRotationAxis();

        transform.Rotate(0, 0, rotationAxisVal * m_rotationSpeed * Time.deltaTime);
	    if(rotationAxisVal > 0)
        {
            if (!m_SpinRight.isPlaying) { m_SpinRight.Play(); }
        }
        else
        {
            m_SpinRight.Stop();
        }

        if (rotationAxisVal < 0)
        {
            if (!m_SpinLeft.isPlaying) { m_SpinLeft.Play(); }
        }
        else
        {
            m_SpinLeft.Stop();
        }

        transform.Translate(m_discInputController.GetHorizontalAxis() * m_movementSpeed * Time.deltaTime,
                            m_discInputController.GetVerticalAxis() * m_movementSpeed * Time.deltaTime,
                            0, Space.World);
        if (m_Points <= m_Death)
        {
            itsDeadJimTakeItsStuff();
        }
        if (m_Points >= MyPrecious.Instance.PointsToWin)
        {
            MyPrecious.Instance.ggEZ(myPlayerNumber);
        }
    }

    private void itsDeadJimTakeItsStuff()
    {
        gameObject.SetActive(false);
        MyPrecious.Instance.playersThatAreAlive.Remove(this);
        MyPrecious.Instance.ggEZ();
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
                    PlayerHitParticles.Instance.transform.position = bulleter.transform.position;
                    PlayerHitParticles.Instance.Play();
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
