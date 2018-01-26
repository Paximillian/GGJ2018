using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick3Controller : IDiscController 
{
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisJ3");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinJ3");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisJ3");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisJ3");
    }
}
