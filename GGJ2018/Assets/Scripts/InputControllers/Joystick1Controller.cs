using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick1Controller : IDiscController {
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisJ1");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinJ1");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisJ1");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisJ1");
    }
}
