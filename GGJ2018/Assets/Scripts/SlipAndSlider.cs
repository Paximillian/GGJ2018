using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SlipAndSlider : MonoBehaviour {
    private Slider m_slider;

    public GameObject spoon;
    public GameObject slider;

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

    public void MySLIDERS(float value)
    {
        if (value < spoon.transform.childCount)
        {
            for (int i = spoon.transform.childCount - 1; i < value; i--)
            {
                Destroy(spoon.transform.GetChild(i));
            }
        }
        else {
            for (int i = spoon.transform.childCount; i < value; i++)
            {
                GameObject newspoon = Instantiate(slider);
                newspoon.transform.SetParent(spoon.transform);
                newspoon.transform.localPosition = Vector3.down * i * 3f;
            }
        }
    }

}
