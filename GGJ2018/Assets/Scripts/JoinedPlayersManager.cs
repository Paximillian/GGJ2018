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
                StartGameButton.interactable = true;

                data.NumberOfPlayers++;
                data.JoinedControllers.Add(data.NumberOfPlayers, controller);
                
                Instantiate<GameObject>(PlayerIconPrefab, transform);

                if (data.NumberOfPlayers == 4) {
                    PressKeyToJoinText.gameObject.SetActive(false);
                }
            }
        } 
    }
}
