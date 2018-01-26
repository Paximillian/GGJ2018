using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeSlowerer : PathMakerBetterer
{
    float sloweyHowMucher = 0.7f;
    public override void MakeBulleterBettererBeforeItKnowDaWae(RadioWaveController bulleter)
    {
        bulleter.speed *= sloweyHowMucher;
    }

    public override void MakeBulleterBettererNowDatItKnowDaWae(RadioWaveController bulleter)
    {
        bulleter.speed *= 1/ sloweyHowMucher;
    }
}
