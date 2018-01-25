using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint NextPoint;
    public Waypoint PrevPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wave")) {
            collision.gameObject.GetComponent<RadioWaveController>().SetWaypoint(NextPoint,PrevPoint);
        }
    }

}
