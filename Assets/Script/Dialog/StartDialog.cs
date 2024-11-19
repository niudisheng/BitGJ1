using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    public TextAsset TextAsset;
    public DialogManager DialogManager;
    public string thisNPC;
    public string otherNPC;
    public bool isPause;
    public bool isRead;

    public void StartDialogs()
    {
        DialogManager.dialogue.SetActive(true);
        DialogManager.oneName = thisNPC;
        DialogManager.twoName = otherNPC;
        DialogManager.isPause = this.isPause;
        DialogManager.ReadText(TextAsset);
        DialogManager.ShowDialogRow();
    }
}
