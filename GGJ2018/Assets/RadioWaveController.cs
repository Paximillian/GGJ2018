using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RadioWaveController : MonoBehaviour {

    public float speed;

    private Waypoint currentTarget;

    private Vector3 movedir;

    private bool? directionInRoute;

    [SerializeField]
    [Range(0, 90)]
    private int firstAngleOfShoostings = 60;
    
    private void Awake()
    {
        Random.InitState(DateTime.Now.Millisecond);
    }

    private void OnEnable()
    {
        iCanHazStartValuez();
    }

    private void iCanHazStartValuez()
    {
        float angle = Random.Range(-firstAngleOfShoostings, firstAngleOfShoostings);
        movedir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            movedir = (currentTarget.transform.position - transform.position).normalized;
        }

        transform.Translate(movedir * speed * Time.deltaTime);
    }

    public void SetWaypoint(Waypoint targetForwards, Waypoint targetBackwards)
    {
        if (!directionInRoute.HasValue)
        {
            if (targetForwards == null && targetBackwards != null)
            {
                directionInRoute = true;
            }
            else if (targetForwards != null && targetBackwards == null)
            {
                directionInRoute = false;
            }
        }
        if ((directionInRoute.Value ? targetForwards : targetBackwards) == null)
        {
            transform.SetParent(null, true);
        }
        currentTarget = (directionInRoute.Value ? targetForwards : targetBackwards);
    }
}
