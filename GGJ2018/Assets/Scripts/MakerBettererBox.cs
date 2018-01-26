using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerBettererBox : RadioWaveController
{

    public PathMakerBetterer insides;

    private void Start()
    {
        insides = new BulleterFasterer();
    }
}
