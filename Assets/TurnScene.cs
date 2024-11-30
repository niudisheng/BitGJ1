using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnScene : MonoBehaviour
{
    public string childScene;
    public string adoScene;
    public string midScene;
    public BoolSO isChild;
    public BoolSO isAdo;
    public BoolSO isMld;
    public ObjectEventSO GoNextSceneEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isChild.isDone & !isAdo.isDone & !isMld.isDone)
        {
            GoNextScene(childScene);
        }
        else if((isChild.isDone & !isAdo.isDone & !isMld.isDone))
        {
            GoNextScene(adoScene);
        }
        else
        {
            GoNextScene(midScene);
        }

    }
    public void GoNextScene(string sceneName)
    {
        GoNextSceneEvent.RaiseEvent(sceneName,this);
        // SceneLoadManager.LoadScene(sceneName);
    }
}
