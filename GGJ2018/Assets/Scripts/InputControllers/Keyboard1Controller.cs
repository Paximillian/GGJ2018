using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard1Controller : MonoBehaviour, IDiscController {
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalK1");
    }

    public bool GetJoinButton() {
        return Input.GetKeyDown("JoinK1");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationK1");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalK1");
    }
}
