using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint NextPoint;
    public Waypoint PrevPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wave"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            collision.gameObject.GetComponent<RadioWaveController>().SetWaypoint(NextPoint,PrevPoint);
        }
    }

}
