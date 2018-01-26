using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Toggle))]
public class ToggleSetter : MonoBehaviour 
{
    private Toggle m_toggle;
    private int m_toggleValue;

    private void Awake() 
    {
        m_toggle = GetComponent<Toggle>();
        m_toggleValue = transform.GetSiblingIndex() + 1;
        m_toggle.onValueChanged.AddListener((x) => { OnToggleOn(); });
    }

    private void OnToggleOn() 
    {
        if (m_toggle.isOn) 
        {
            MyPrecious.Instance.NumberOfPlayers = m_toggleValue;
        }
    }
}
