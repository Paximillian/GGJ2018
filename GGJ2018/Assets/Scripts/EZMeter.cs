using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EZMeter : MonoBehaviour
{
    [SerializeField]
    private Image m_FillColor;

    // Use this for initialization
    void Start()
    {
        float ezRating = GetComponentInChildren<Slider>().value = MyPrecious.Instance.GetEzRating();

        if(ezRating > 0.6f)
        {
        }
        else if(ezRating > 0.3f)
        {
            m_FillColor.color = Color.yellow;
        }
        else
        {
            m_FillColor.color = Color.red;
        }
    }
}
