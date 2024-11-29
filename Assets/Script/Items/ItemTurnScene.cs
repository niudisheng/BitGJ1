using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTurnScene : NPCInteractor
{
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
        SceneLoadManager.LoadScene(sceneName);
        Debug.Log("trun");
    }

}
