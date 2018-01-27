using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard2Controller : IDiscController {
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalAxisK2");
    }

    public bool GetJoinKeyDown() {
        return Input.GetButtonDown("JoinK2");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationAxisK2");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalAxisK2");
    }
}
