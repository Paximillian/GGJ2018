using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerBettererBox : RadioWaveController
{
    public PathMakerBetterer insides;

    private void OnEnable()
    {
        insides = new BulleterFasterer();
    }
}
