using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public DIalogDataSO DIalogDataSO;
    public DialogManager DialogManager;
    public bool isRead;

    public void StartDialogs()
    {
        DialogManager.dialogue.SetActive(true);
        DialogManager.oneName = DIalogDataSO.thisNPC;
        DialogManager.twoName = DIalogDataSO.otherNPC;
        DialogManager.isPause = DIalogDataSO.isPause;
        DialogManager.ReadText(DIalogDataSO.TextAsset);
        DialogManager.ShowDialogRow();
    }
    public void SayOk()
    {
        Debug.Log("ok");
    }
}
