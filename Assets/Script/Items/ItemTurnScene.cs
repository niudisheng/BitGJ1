using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTurnScene : NPCInteractor
{
    public BoolSO BoolSO;
    public string sceneName;
    // Start is called before the first frame update
    private void Awake()
    {
        base.Awake();
        if (BoolSO != null)
        {
            if (BoolSO.isDone == true)
            {
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
        SceneLoadManager.LoadScene(sceneName);
        Debug.Log("trun");
    }

}
