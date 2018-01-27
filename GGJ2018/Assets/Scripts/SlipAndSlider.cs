using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SlipAndSlider : MonoBehaviour {
    private Slider m_slider;

	private void Awake ()
    {
        m_slider = GetComponent<Slider>();
		
	}

    public void myPerrrcious()
    {
        if (Application.isPlaying)
        {
            MyPrecious.Instance.PointsToWin = (int)m_slider.value;
        }
    }

}
