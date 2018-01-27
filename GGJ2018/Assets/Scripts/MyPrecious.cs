﻿using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControllerPapa;

public class MyPrecious : Singleton<MyPrecious> 
{
    [Range(0, 4)]
    private int m_numberOfPlayers = 0;

    [SerializeField]
    [Range(1, 100)]
    private int m_pointsToWin = 10;

    public int winnerWinnerChickenDinner;

    private IDiscController[] m_standbyControllers =
    {
        new Keyboard1Controller(ControllerType.keyboard, "Keyboard 1"),
        new Keyboard2Controller(ControllerType.keyboard, "Keyboard 2"),
        //new MouseController(ControllerType.mouse, "Mouse"),
        new Joystick1Controller(ControllerType.joystick, "Joystick 1"),
        new Joystick2Controller(ControllerType.joystick, "Joystick 2"),
        new Joystick3Controller(ControllerType.joystick, "Joystick 3"),
        new Joystick4Controller(ControllerType.joystick, "Joystick 4"),
    };

    public IDiscController[] StandbyControllers {
        get {
            return m_standbyControllers;
        }
        set {
            m_standbyControllers = value;
        }
    }

    public List<DiscRotationController> playersThatAreAlive;

    private Dictionary<int, IDiscController> m_joinedControllers =  new Dictionary<int, IDiscController>();

    public Dictionary<int, IDiscController> JoinedControllers {
        get {
            return m_joinedControllers;
        }

        set {
            m_joinedControllers = value;
        }
    }
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

    public void ggEZ(int playerNumber = -1)
    {
        //Somone Died
        if (playerNumber == -1)
        {
            if (playersThatAreAlive.Count == 1)
            {
                winnerWinnerChickenDinner = playersThatAreAlive[0].MyPlayerNumber;
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerWinnerChickenDinner");
            }
        }
        else //we know who won 
        {
            winnerWinnerChickenDinner = playerNumber;
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerWinnerChickenDinner");
        }
    }

}