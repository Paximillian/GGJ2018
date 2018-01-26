using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RadioWaveController : MonoBehaviour {

    public float speed;
    private Waypoint m_LastTarget;
    private Waypoint currentTarget;

    private Vector3 movedir;

    private bool? directionInRoute;
    
    [SerializeField]
    [Range(0, 90)]
    private int firstAngleOfShoostings = 60;
    
    public DiscRotationController BoomerOfMe { get; private set; }

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

    private void MakeBoomier(List<PathMakerBetterer> bettermakerers) {
        foreach (PathMakerBetterer boomierer in bettermakerers) {
            boomierer.MakeBulleterBetterer(this);
        }
    }

    public void SetWaypoint(Waypoint targetForwards, Waypoint targetBackwards) {
        BoomerOfMe = currentTarget?.GetComponentInParent<DiscRotationController>();

        if (!directionInRoute.HasValue) {//Add a direction in route plus upgrades?
            if (targetForwards != null && targetBackwards == null)
            {
                directionInRoute = true;
                MakeBoomier(targetForwards.boxOfMakerBetterers);
            }
            else if (targetForwards == null && targetBackwards != null)
            {
                directionInRoute = false;
                MakeBoomier(targetBackwards.boxOfMakerBetterers);
            }
        }
        if ((directionInRoute.Value ? targetForwards : targetBackwards) == null)
        {
            transform.SetParent(null, true);
            movedir = (currentTarget.transform.position - m_LastTarget.transform.position).normalized * 2;
        }

        m_LastTarget = currentTarget;
        currentTarget = (directionInRoute.Value ? targetForwards : targetBackwards);
    }
}
