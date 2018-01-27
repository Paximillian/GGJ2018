using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPapa
{
    public enum ControllerType 
    {
        keyboard,
        joystick,
        mouse,
    }

    public ControllerType Type;
    public string Name;

    public ControllerPapa(ControllerType type, string name) {
        Name = name;
        Type = type;
    }
}
