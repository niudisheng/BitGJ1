using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button loadButton;
    public Button helpButton;
    public Button exitButton;
    public ObjectEventSO loadGame;
    private void OnEnable()
    {
        //TODO: 没有做存档逻辑
        startButton.onClick.AddListener(StartGame);  
        loadButton.onClick.AddListener(StartGame);  
    }

    private void StartGame()
    {
        loadGame.RaiseEvent(null,this);
    }



}
