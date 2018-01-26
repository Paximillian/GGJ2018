using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleterFasterer : PathMakerBetterer
{
    public override void MakeBulleterBetterer(RadioWaveController bulleter)
    {
        bulleter.speed *= 2f;
    }
}
