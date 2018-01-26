using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPrecious : Singleton<MyPrecious> 
{
    [SerializeField]
    [Range(1, 4)]
    private int m_numberOfPlayers;

    [SerializeField]
    [Range(1, 100)]
    private int m_pointsToWin;


    public int NumberOfPlayers 
    {
        get { return m_numberOfPlayers; }
        set { m_numberOfPlayers = value; }
    }

    public int PointsToWin
    {
        get { return m_pointsToWin; }
        set { m_pointsToWin = value; }
    }
}