using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiscController
{
    bool GetJoinKeyDown();

    float GetRotationAxis();

    float GetHorizontalAxis();

    float GetVerticalAxis();
}
