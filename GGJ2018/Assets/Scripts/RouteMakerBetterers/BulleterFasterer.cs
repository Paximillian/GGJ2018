using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleterFasterer : PathMakerBetterer
{
    public override void MakeBulleterBettererBeforeItKnowDaWae(RadioWaveController bulleter)
    {
        
    }

    public override void MakeBulleterBettererNowDatItKnowDaWae(RadioWaveController bulleter)
    {
        bulleter.speed *= 2f;
    }
}
