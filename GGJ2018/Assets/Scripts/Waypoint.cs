using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    
    [SerializeField]
    private AudioSource m_VirusAbsorbSound;

    [SerializeField]
    private AudioSource m_PillAbsorbSound;

    [SerializeField]
    private AudioSource m_PillKidnapAbsorbSound;

    [SerializeField]
    private ParticleSystem m_PillAbsorbParticles;

    public Waypoint NextPoint;
    public Waypoint PrevPoint;

    public List<PathMakerBetterer> boxOfMakerBetterers = new List<PathMakerBetterer>();

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("wave"))
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            collision.gameObject.GetComponent<RadioWaveController>().SetWaypoint(NextPoint,PrevPoint);

            m_VirusAbsorbSound.Play();
            m_PillAbsorbParticles.Play();
        }

        else if (collision.gameObject.CompareTag("bettermaker"))
        {
            UpgradeWae(collision.gameObject.GetComponent<MakerBettererBox>());
            collision.gameObject.SetActive(false);
        }
    }

    private void UpgradeWae(MakerBettererBox box)
    {
        if (NextPoint != null && PrevPoint != null) return;

        boxOfMakerBetterers.Add(box.insides);
        if (NextPoint == null) { PrevPoint.UpgradeWaePlox(box, this); }
        else { NextPoint.UpgradeWaePlox(box, this); }

        if (box.LastTarget == this)
        {
            m_PillAbsorbSound.Play();
        }
        else
        {
            m_PillKidnapAbsorbSound.Play();
        }
    }

    public void UpgradeWaePlox(MakerBettererBox box, Waypoint ploxer)
    {
        boxOfMakerBetterers.Add(box.insides);
        if (ploxer == NextPoint) { PrevPoint?.UpgradeWaePlox(box, this); }
        else { NextPoint?.UpgradeWaePlox(box, this); }
    }
}
