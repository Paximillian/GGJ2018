using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsFromSlider : MonoBehaviour {

    public Slider Points;
    public Text self;

    public void updateText()
    {
        self.text = Points.value.ToString();
    }
}
