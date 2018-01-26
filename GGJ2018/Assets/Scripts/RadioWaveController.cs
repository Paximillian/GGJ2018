using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RadioWaveController : MonoBehaviour {

    public float speed;
    private Waypoint m_LastTarget;
    private Waypoint currentTarget;

    static float goweAwayeNum = 1f;

    private Vector3 movedir;

    private bool? directionInRoute;
    
    [SerializeField]
    [Range(0, 90)]
    private int firstAngleOfShoostings = 60;
    
    public DiscRotationController BoomerOfMe { get; private set; }

    public DiscRotationController masterWhoGaveSock { get; private set; }

    public bool IzFollowDeWae { get { return currentTarget; } }

    private void Awake()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(movedir * speed * Time.deltaTime, Space.World);
        }
    }

    private void MakeBoomier(List<PathMakerBetterer> bettermakerers, bool knowDaWae) {
        foreach (PathMakerBetterer boomierer in bettermakerers) {
            if (boomierer.sleepy == knowDaWae) { boomierer.MakeBulleterBetterer(this); }
        }
    }

    public void SetWaypoint(Waypoint targetForwards, Waypoint targetBackwards) {

        masterWhoGaveSock = BoomerOfMe;

        BoomerOfMe = currentTarget?.GetComponentInParent<DiscRotationController>();

        if (BoomerOfMe != masterWhoGaveSock) {
            BoomerOfMe?.makeHurtyBymaster(masterWhoGaveSock, this);
        }

        if (!directionInRoute.HasValue)
        {//Enter to wae
            if (targetForwards != null && targetBackwards == null)
            {
                directionInRoute = true;
                MakeBoomier(targetForwards.boxOfMakerBetterers, false);
            }
            else if (targetForwards == null && targetBackwards != null)
            {
                directionInRoute = false;
                MakeBoomier(targetBackwards.boxOfMakerBetterers, false);
            }
        }
        if ((directionInRoute.Value ? targetForwards : targetBackwards) == null) //Exit from wae
        {
            transform.SetParent(null, true);
            MakeBoomier(((!directionInRoute.Value) ? targetForwards : targetBackwards).boxOfMakerBetterers, true);
            movedir = (currentTarget.transform.position - m_LastTarget.transform.position).normalized * goweAwayeNum;
        }

        m_LastTarget = currentTarget;
        currentTarget = (directionInRoute.Value ? targetForwards : targetBackwards);
    }
}
