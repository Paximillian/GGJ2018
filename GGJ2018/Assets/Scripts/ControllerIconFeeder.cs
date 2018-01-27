using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ControllerIconFeeder : MonoBehaviour 
{
    [SerializeField]
    private Image m_image;

    [SerializeField]
    private Text m_controllerText;

    [SerializeField]
    private Text m_playerText;

    public void SetControllerText(string text) 
    {
        m_controllerText.text = text;
    }

    public void SetPlayerText(string text) {
        m_playerText.text = text;
    }

    public void SetSprite(Sprite sprite) 
    {
        m_image.sprite = sprite;
    }
}
