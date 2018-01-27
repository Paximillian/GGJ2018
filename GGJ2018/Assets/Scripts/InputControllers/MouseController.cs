using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : ControllerPapa, IDiscController {
    public MouseController(ControllerType type, string name) : base(type, name) {
    }

    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisM");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinM");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisM");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisM");
    }
}