using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour, IDiscController 
{
    public float GetHorizontalAxis() {
        return Input.GetAxis("HorizontalM");
    }

    public bool GetJoinButton() {
        return Input.GetKeyDown("JoinM");
    }

    public float GetRotationAxis() {
        return Input.GetAxis("RotationM");
    }

    public float GetVerticalAxis() {
        return Input.GetAxis("VerticalM");
    }
}