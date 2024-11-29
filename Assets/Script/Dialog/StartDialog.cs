using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public bool isStartFirst;
    public GameObject dialogue;
    public DIalogDataSO DIalogDataSO;
    public DialogManager DialogManager;
    public bool isRead;
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
    }
}
