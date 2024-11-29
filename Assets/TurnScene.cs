using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnScene : MonoBehaviour
{
    public string sceneName;
    public ObjectEventSO GoNextSceneEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoNextScene();
    }
    public void GoNextScene()
    {
        GoNextSceneEvent.RaiseEvent(sceneName,this);
        // SceneLoadManager.LoadScene(sceneName);
    }
}
