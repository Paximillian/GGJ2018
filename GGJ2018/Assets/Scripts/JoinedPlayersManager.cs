using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinedPlayersManager : MonoBehaviour 
{
    private MyPrecious data;

    public Button StartGameButton;

    public GameObject PlayerIconPrefab;

    public Text PressKeyToJoinText;

    [Header("Sprites")]

    [SerializeField]
    Sprite m_keyboardSprite;

    [SerializeField]
    Sprite m_joystickSprite;

    [SerializeField]
    Sprite m_mouseSprite;

    private void Awake()
    {
        data = MyPrecious.Instance;
    }

    private void Update() 
    {
        foreach (var controller in data.StandbyControllers) 
        {
            if (   data.NumberOfPlayers < 4 
                && !data.JoinedControllers.ContainsValue(controller) 
                && controller.GetJoinKeyDown())
            {
                data.NumberOfPlayers++;
                data.JoinedControllers.Add(data.NumberOfPlayers, controller);
                
                GameObject gameObject = Instantiate<GameObject>(PlayerIconPrefab, transform);
                ControllerIconFeeder feeder = gameObject.GetComponent<ControllerIconFeeder>();
                if (feeder != null) {
                    feeder.SetControllerText((controller as ControllerPapa)?.Name);

                    switch ((controller as ControllerPapa).Type) {
                        case ControllerPapa.ControllerType.keyboard:
                            feeder.SetSprite(m_keyboardSprite);
                            break;
                        case ControllerPapa.ControllerType.joystick:
                            feeder.SetSprite(m_joystickSprite);
                            break;
                        case ControllerPapa.ControllerType.mouse:
                            feeder.SetSprite(m_mouseSprite);
                            break;
                    }

                    feeder.SetPlayerText($"Player {data.NumberOfPlayers}");

                    if (data.NumberOfPlayers == 2) {
                        StartGameButton.interactable = true; 
                    }

                    if (data.NumberOfPlayers == 4) {
                        PressKeyToJoinText.GetComponent<Text>().enabled = false;
                }
                }
            }
        }
    }
}