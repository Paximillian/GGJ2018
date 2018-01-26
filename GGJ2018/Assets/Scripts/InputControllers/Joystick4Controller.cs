using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick4Controller : MonoBehaviour, IDiscController
{
    public float GetHorizontalAxis() 
    {
        return Input.GetAxis("HorizontalJ4");
    }

    public bool GetJoinButton()
    {
        return Input.GetKeyDown("JoinJ4");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationJ4");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalJ4");
    }
}
