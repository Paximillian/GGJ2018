﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick4Controller : IDiscController
{
    public float GetHorizontalAxis() 
    {
        return Input.GetAxis("HorizontalAxisJ4");
    }

    public bool GetJoinKeyDown()
    {
        return Input.GetButtonDown("JoinJ4");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisJ4");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisJ4");
    }
}
