using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeWae : MonoBehaviour {

    public List<Waypoint> DePoints;

    private void Awake()
    {
        for (int i = 0; i < DePoints.Count; i++) {
            if (i > 0) {
                DePoints[i].NextPoint = DePoints[i - 1];
            }
            if (i < DePoints.Count - 1)
            {
                DePoints[i].PrevPoint = DePoints[i + 1];
            }
        }
    }
}
