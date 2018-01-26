using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick3Controller : MonoBehaviour, IDiscController 
{
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalJ3");
    }

    public bool GetJoinButton() {
        return Input.GetKeyDown("JoinJ3");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationJ3");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalJ3");
    }
}
