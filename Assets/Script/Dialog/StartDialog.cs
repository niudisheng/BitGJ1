using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartDialog : MonoBehaviour
{
    public string sceneToLaod;
    public bool isStartFirst;
    public GameObject dialogue;
    public DIalogDataSO DIalogDataSO;
    public DialogManager DialogManager;
    public bool isRead;
    public StartDialog dialog;
    private void Awake()
    {
        dialogue = GameObject.Find("DialogManager");
        DialogManager = dialogue.GetComponent<DialogManager>();
        if (isStartFirst)
        {
            StartDialogs();
        }
    }
    public void StartDialogs()
    {
        DialogManager.dialogue.SetActive(true);
        DialogManager.oneName = DIalogDataSO.thisNPC;
        DialogManager.twoName = DIalogDataSO.otherNPC;
        DialogManager.isPause = DIalogDataSO.isPause;
        DialogManager.ReadText(DIalogDataSO.TextAsset);
        DialogManager.ShowDialogRow();
        if (dialog != null)
        {
            DialogManager.UnityAction += dialog.StartDialogs;
        }
        if (dialogue != null) 
        {
            DialogManager.UnityAction += TurnScene;
        }

    }
    public void TurnScene()
    {
        SceneLoadManager.LoadScene(sceneToLaod);
    }
}
