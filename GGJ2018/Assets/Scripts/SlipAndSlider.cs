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

            foreach(Transform child in spoon.transform)
            {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < value; i++)
            {
                GameObject newspoon = Instantiate(slider);
                newspoon.transform.SetParent(spoon.transform);
                newspoon.transform.localPosition = Vector3.down * i * 3f;
            }
        }
    }
