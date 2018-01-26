using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick2Controller : MonoBehaviour, IDiscController {
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalJ2");
    }

    public bool GetJoinButton() {
        return Input.GetKeyDown("JoinJ2");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationJ2");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalJ2");
    }
}
