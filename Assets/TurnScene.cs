using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnScene : MonoBehaviour
{
    public string sceneName;
    public void GoNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
