using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RadioWaveController : MonoBehaviour {

    public float speed;

    public float spinnySpeed = 5f;
    public Waypoint LastTarget { get; set; }
    private Waypoint currentTarget;

    [SerializeField]
    public float spinner = 100f;

    static float goweAwayeNum = 1f;

    private Vector3 movedir;

    private float rot = 0f;
    private bool? directionInRoute;
    
    [SerializeField]
    [Range(0, 90)]
    private int firstAngleOfShoostings = 60;
    private float m_InitialSpeed;

    [SerializeField]
    private AudioSource m_SpawnSound;

    [SerializeField]
    private AudioSource m_PlayerShootSound;

    [SerializeField]
    private ParticleSystem m_PlayerShootParticles;

    public DiscRotationController BoomerOfMe { get; private set; }

    public DiscRotationController masterWhoGaveSock { get; private set; }

    public bool IzFollowDeWae { get { return currentTarget; } }

    private void Awake()
    {
        m_InitialSpeed = speed;
        Random.InitState(DateTime.Now.Millisecond);
    }

    private void OnEnable()
    {
        iCanHazStartValuezPl0x();
    }

    private void iCanHazStartValuezPl0x()
    {
        float angle = Random.Range(-firstAngleOfShoostings, firstAngleOfShoostings);
        movedir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.down;
        BoomerOfMe = null;
        directionInRoute = null;
        LastTarget = null;
        currentTarget = null;
        speed = m_InitialSpeed;

        m_SpawnSound.Play();
        m_PlayerShootParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
            transform.right = Vector3.Lerp(transform.right, 
                (currentTarget.transform.position - transform.position).normalized,
                spinnySpeed * Time.deltaTime);
            //transform.right = (currentTarget.transform.position - transform.position).normalized;
        }
        else
        {
            transform.Translate(movedir * speed * Time.deltaTime, Space.World);
            transform.right = Vector3.Lerp(transform.right,
                movedir.normalized,
                spinnySpeed * Time.deltaTime);
            //transform.right = movedir.normalized;
        }

        rot += Time.deltaTime;
        transform.Rotate(Vector3.right * rot * spinner);
    }

    private void MakeBoomier(List<PathMakerBetterer> bettermakerers, bool knowDaWae) {
        foreach (PathMakerBetterer boomierer in bettermakerers) {
            if (!knowDaWae)
            {
                boomierer.MakeBulleterBettererBeforeItKnowDaWae(this);
            }
            else
            {
                boomierer.MakeBulleterBettererNowDatItKnowDaWae(this);
            }
        }
    }

    public void SetWaypoint(Waypoint targetForwards, Waypoint targetBackwards) {

        masterWhoGaveSock = BoomerOfMe;

        DiscRotationController temp = (targetForwards == null ? targetForwards : targetBackwards)?.holderOfMe;

        if (temp != null) { BoomerOfMe = temp; }

        if (BoomerOfMe != masterWhoGaveSock) {
            BoomerOfMe?.makeHurtyBymaster(masterWhoGaveSock, this);
        }

        if (!directionInRoute.HasValue)
        {//Enter to wae
            if (targetForwards != null && targetBackwards == null)
            {
                directionInRoute = true;

                MakeBoomier(targetForwards.holderOfMe.boxOfMakerBetterers, false);
            }
            else if (targetForwards == null && targetBackwards != null)
            {
                directionInRoute = false;
                MakeBoomier(targetBackwards.holderOfMe.boxOfMakerBetterers, false);
            }
        }
        if ((directionInRoute.Value ? targetForwards : targetBackwards) == null) //Exit from wae
        {
            transform.SetParent(null, true);

            MakeBoomier((targetForwards != null ? targetForwards : targetBackwards).holderOfMe.boxOfMakerBetterers, true);
            movedir = (currentTarget.transform.position - LastTarget.transform.position).normalized * goweAwayeNum;

            m_PlayerShootSound.Play();
        }

        if (currentTarget != null) {
            LastTarget = currentTarget;
        }
        currentTarget = (directionInRoute.Value ? targetForwards : targetBackwards);
    }
}
