using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartDialog : MonoBehaviour
{
    public ObjectEventSO GoNextSceneEvent;
    public string sceneToLaod;
    public bool isStartFirst;
    public GameObject dialogue;
    public DIalogDataSO DIalogDataSO;
    public DialogManager DialogManager;
    public bool isRead;
    public StartDialog dialog;
    private void Awake()
    {
        isRead = false;

        //WaitTime(0.3f);
    }
    private void Update()
    {
        if (dialogue == null)
        {
            dialogue = GameObject.FindWithTag("DialogManager");
            DialogManager = dialogue.GetComponent<DialogManager>();
            if (isStartFirst & !isRead)
            {
                StartDialogs();
            }
        }

    }
    public void StartDialogs()
    {
        DialogManager.isOver = false;
        if (dialog != null)
        {
            DialogManager.UnityAction += dialog.StartDialogs;
        }
        if (GoNextSceneEvent != null)
        {
            DialogManager.UnityAction += TurnScene;
        }
        DialogManager.dialogue.SetActive(true);
        DialogManager.oneName = DIalogDataSO.thisNPC;
        DialogManager.twoName = DIalogDataSO.otherNPC;
        DialogManager.isPause = DIalogDataSO.isPause;
        DialogManager.ReadText(DIalogDataSO.TextAsset);
        DialogManager.ShowDialogRow();
        isRead = true;
        isStartFirst = false;
        if (dialog != null&DialogManager.isOver)
        {
            DialogManager.UnityAction -= dialog.StartDialogs;
        }
        if (GoNextSceneEvent != null & DialogManager.isOver)
        {
            DialogManager.UnityAction -= TurnScene;
        }

    }
    public void TurnScene()
    {
         GoNextSceneEvent.RaiseEvent(sceneToLaod, this);
    }
    //private IEnumerator WaitTime(float delayTime)
    //{
    //    yield return new WaitForSeconds(delayTime);
    //    dialogue = GameObject.FindWithTag("DialogManager");
    //    DialogManager = dialogue.GetComponent<DialogManager>();
    //    if (isStartFirst & !isRead)
    //    {
    //        StartDialogs();
    //    }
    //}
}
