using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWaveController : MonoBehaviour {

    public float speed;

    private Waypoint currentTarget;

    private Vector3 movedir;

    private bool? directionInRoute;

    private void Start()
    {
        movedir = transform.right;
    }
    // Update is called once per frame
    void Update () {
        if (currentTarget != null) {
            movedir = (currentTarget.transform.position - transform.position).normalized;
        }
        transform.Translate(movedir * speed * Time.deltaTime);
	}

    public void SetWaypoint(Waypoint targetForwards, Waypoint targetBackwards) {
        if (!directionInRoute.HasValue) {
            if (targetForwards == null && targetBackwards != null)
            {
                directionInRoute = true;
            }
            else if (targetForwards != null && targetBackwards == null)
            {
                directionInRoute = false;
            }
        }
        if ((directionInRoute.Value? targetForwards : targetBackwards) == null) {
            transform.SetParent(null, true);
        }
        currentTarget = (directionInRoute.Value ? targetForwards : targetBackwards);
    }
}
