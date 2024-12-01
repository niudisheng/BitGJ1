using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemTurnScene : NPCInteractor
{
    public bool isNeedFinish;
    public BoolSO isNotFinish;
    [Header("切换到的场景")]
    public string sceneName1;
    public string sceneName2;
    //public ObjectEventSO GoNextSceneEvent;
    private void Awake()
    {
        base.Awake();
        if (isNeedFinish)
        {
            if (isNotFinish.isDone)
            {
                OnClick += OnInteract2;
            }
            else if(!isNotFinish.isDone)
            {
                if (sceneName2 != null)
                    OnClick += OnInteract1;
            }
        }
        else
        {
            OnClick += OnInteract1;
        }

    }

    // Update is called once per frame
    public void OnInteract1()
    {
        if (itemData.isCompleted)
        {
            return;
        }
        else
        {
            //TODO:应该也需要调用描述
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(sceneName1, LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName1));
            };
            Debug.Log("trun");
        }
    }
    public void OnInteract2()
    {
        if (itemData.isCompleted)
        {
            return;
        }
        else
        {
            //TODO:应该也需要调用描述
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(sceneName2, LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName2));
            };
           Debug.Log("trun");
        }
    }
    public void ItemToTurnScene()
    {
        SceneManager.LoadSceneAsync(sceneName1, LoadSceneMode.Additive);
    }
}
