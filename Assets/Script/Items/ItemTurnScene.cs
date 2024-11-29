using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTurnScene : NPCInteractor
{
    public bool isNeedFinish;
    public BoolSO isFinish;
    [Header("切换到的场景")]
    public string sceneName1;
    public string sceneName2;
    // Start is called before the first frame update
    private void Awake()
    {
        base.Awake();
        if (isNeedFinish)
        {
            if (!isFinish.isDone)
            {
                OnClick += OnInteract1;
            }
            else if(isFinish.isDone)
            {
                OnClick += OnInteract2;
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
            SceneLoadManager.LoadScene(sceneName1);
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
            SceneLoadManager.LoadScene(sceneName2);
            Debug.Log("trun");
        }
    }

}
