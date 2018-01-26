using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public Waypoint NextPoint;
    public Waypoint PrevPoint;

    public List<PathMakerBetterer> boxOfMakerBetterers = new List<PathMakerBetterer>();

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wave"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            collision.gameObject.GetComponent<RadioWaveController>().SetWaypoint(NextPoint,PrevPoint);
        }

        else if (collision.gameObject.CompareTag("bettermaker"))
        {
            UpgradeWae(collision.gameObject.GetComponent<MakerBettererBox>());
            collision.gameObject.SetActive(false);
        }
    }

    private void UpgradeWae(MakerBettererBox box) {
        if (NextPoint != null && PrevPoint != null) return;

        boxOfMakerBetterers.Add(box.insides);
        if (NextPoint == null) { PrevPoint.UpgradeWaePlox(box, this); }
        else { NextPoint.UpgradeWaePlox(box, this); }
    }

    public void UpgradeWaePlox(MakerBettererBox box, Waypoint ploxer)
    {
        boxOfMakerBetterers.Add(box.insides);
        if (ploxer == NextPoint) { PrevPoint?.UpgradeWaePlox(box, this); }
        else { NextPoint?.UpgradeWaePlox(box, this); }
    }
}
