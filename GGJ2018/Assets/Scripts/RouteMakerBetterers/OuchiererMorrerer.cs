using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuchiererMorrerer : PathMakerBetterer
{

    float minWaethere = 10;
    float maxWaethere = 30;
    public override void MakeBulleterBettererBeforeItKnowDaWae(RadioWaveController bulleter)
    {

    }

    public override void MakeBulleterBettererNowDatItKnowDaWae(RadioWaveController bulleter)
    {
        
        //bullet.transform.position = bulleter.transform.position;
        //int howMucher = ((Random.Range(0, 1)) * 2) -1;
        bulleter.Reproduce(minWaethere, maxWaethere);
    }
}
