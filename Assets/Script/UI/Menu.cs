using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button loadButton;
    public Button helpButton;
    public Button exitButton;
    public ObjectEventSO startGame;
    public ObjectEventSO GoNextSceneEvent;
    private void Awake()
    {
        SceneManager.LoadSceneAsync("permanent", LoadSceneMode.Additive);
    }
    private void OnEnable()
    {
        //TODO: 没有做存档逻辑
        startButton.onClick.AddListener(StartGame);  
        loadButton.onClick.AddListener(TestLoadGame);  
        loadButton.onClick.AddListener(Application.Quit);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        //SceneManager.UnloadSceneAsync("Mainmenu");
        //SceneManager.LoadSceneAsync("Old1", LoadSceneMode.Additive).completed += (op) =>
        //{
        //    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Old1"));
        //};
        gameObject.SetActive(true);
        startGame.RaiseEvent(null, this);
        SceneLoadManager.instance.LoadPlayer();
    }
    
    [ContextMenu("TestLoadGame")]
    private void TestLoadGame()
    {
        startGame.RaiseEvent(FileSaveManager.LoadFromFile(0),this);
    }
    private void ExitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }



}
