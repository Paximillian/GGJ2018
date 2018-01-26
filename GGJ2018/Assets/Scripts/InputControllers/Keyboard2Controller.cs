using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard2Controller : MonoBehaviour, IDiscController {
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalK2");
    }

    public bool GetJoinButton() {
        return Input.GetKeyDown("JoinK2");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationK2");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalK2");
    }
}
