using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TellEmHowItIz : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Text>().text = $"GG {MyPrecious.Instance.HowEZ()}";
    }
}
