using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick2Controller : ControllerPapa, IDiscController {
    public Joystick2Controller(ControllerType type, string name) : base(type, name) {
    }

    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisJ2");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinJ2");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisJ2");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisJ2");
    }
}
