using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiscController
{
    bool GetJoinButton();

    float GetRotationAxis();

    float GetHorizontalAxis();

    float GetVerticalAxis();
}
