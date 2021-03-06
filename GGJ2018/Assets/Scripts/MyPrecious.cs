﻿using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<IDiscController> m_standbyControllers = new List<IDiscController>()
    {
        new Keyboard1Controller(ControllerType.keyboard, "Keyboard 1"),
        new Keyboard2Controller(ControllerType.keyboard, "Keyboard 2"),
        //new MouseController(ControllerType.mouse, "Mouse"),
        new Joystick1Controller(ControllerType.joystick, "Joystick 1"),
        new Joystick2Controller(ControllerType.joystick, "Joystick 2"),
        new Joystick3Controller(ControllerType.joystick, "Joystick 3"),
        new Joystick4Controller(ControllerType.joystick, "Joystick 4"),
    };

    public List<IDiscController> StandbyControllers {
        get {
            return m_standbyControllers;
        }
        set {
            m_standbyControllers = value;
        }
    }


    private void Update() {
        if (Input.GetKey(KeyCode.Return)) 
        {
            if (NumberOfPlayers >= 2) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            }
        }
    }
    public List<DiscRotationController> playersThatAreAlive;

    private DiscRotationController m_VictoriousPlayer;

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

    public void init() 
    {
        NumberOfPlayers = 0;

        DiscRotationController.playerNumberTracker = 0;

        m_joinedControllers = new Dictionary<int, IDiscController>();
        m_standbyControllers = new List<IDiscController>()
        {
            new Keyboard1Controller(ControllerType.keyboard, "Keyboard 1"),
            new Keyboard2Controller(ControllerType.keyboard, "Keyboard 2"),
            //new MouseController(ControllerType.mouse, "Mouse"),
            new Joystick1Controller(ControllerType.joystick, "Joystick 1"),
            new Joystick2Controller(ControllerType.joystick, "Joystick 2"),
            new Joystick3Controller(ControllerType.joystick, "Joystick 3"),
            new Joystick4Controller(ControllerType.joystick, "Joystick 4"),
        };
    }

    public void ggEZ(int playerNumber = -1)
    {
        //Somone Died
        if (playerNumber == -1)
        {
            if (playersThatAreAlive.Count == 1)
            {
                winnerWinnerChickenDinner = playersThatAreAlive[0].MyPlayerNumber;
                m_VictoriousPlayer = playersThatAreAlive[0];
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerWinnerChickenDinner");
                init();
            }
        }
        else //we know who won 
        {
            m_VictoriousPlayer = playersThatAreAlive.Where(playah => playah.MyPlayerNumber == playerNumber).First();

            winnerWinnerChickenDinner = playerNumber;
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinnerWinnerChickenDinner");
            init();
        }
    }

    public string HowEZ()
    {
        float ezRating = GetEzRating();
        
        if(ezRating > 0.6f)
        {
            return "EZ";
        }
        else if (ezRating > 0.3f)
        {
            return "Medium";
        }
        else
        {
            return "Hard";
        }
    }

    public float GetEzRating()
    {
        float ezScore = 0;
        float maxPointsDiff = (PointsToWin + Mathf.Abs(m_VictoriousPlayer.PointsToDie));
        float maxEzScore = (JoinedControllers.Count - 1) * maxPointsDiff;
        ezScore += (JoinedControllers.Count - playersThatAreAlive.Count) * maxPointsDiff;

        foreach (DiscRotationController playah in playersThatAreAlive)
        {
            ezScore += m_VictoriousPlayer.Points - playah.Points;
        }

        return ezScore / maxEzScore;
    }
}