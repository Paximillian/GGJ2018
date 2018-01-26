using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick4Controller : MonoBehaviour, IDiscController
{
    public float GetHorizontalAxis() 
    {
        return Input.GetAxis("HorizontalJ1");
    }

    public bool GetJoinButton()
    {
        return Input.GetKeyDown("JoinJ1");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationJ1");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalJ1");
    }
}
