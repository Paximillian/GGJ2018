using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard1Controller : ControllerPapa, IDiscController {
    public Keyboard1Controller(ControllerType type, string name) : base(type, name) {
    }

    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisK1");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinK1");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisK1");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisK1");
    }
}
