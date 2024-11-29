using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTurnScene : NPCInteractor
{
    
    [Header("切换到的场景")]
    public string sceneName;
    // Start is called before the first frame update
    private void Awake()
    {
        base.Awake();
        OnClick += OnInteract1;

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
            SceneLoadManager.LoadScene(sceneName);
            Debug.Log("trun");
        }
    }

}
