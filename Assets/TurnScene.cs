using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnScene : MonoBehaviour
{
    [Header("最终结局")]
    public DoubleSO child;
    public DoubleSO ado;
    public DoubleSO mid;
    public StartDialog end1;
    public StartDialog end2;
    [Header("传送")]
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
        else if((isChild.isDone & isAdo.isDone & !isMld.isDone))
        {
            GoNextScene(midScene);
        }
        else
        {
            if (child.progress + ado.progress + mid.progress <= 20)
            {
                end1.StartDialogs();
            }
            else
            {
                end2.StartDialogs();
            }
        }

    }
    public void GoNextScene(string sceneName)
    {
        GoNextSceneEvent.RaiseEvent(sceneName,this);
        
    }
}
