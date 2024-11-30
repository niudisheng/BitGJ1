using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartDialog : MonoBehaviour
{
    

    public ObjectEventSO GoNextSceneEvent;
    public string sceneToLaod;
    public bool isStartFirst;
    public GameObject dialogue;
    public DIalogDataSO DIalogDataSO;
    public DialogManager DialogManager;
    public BoolSO isRead;
    public StartDialog dialog;
    private void Update()
    {
        if (isRead != null)
        {
            if (dialogue == null&!isRead.isDone)
            {
            dialogue = GameObject.FindWithTag("DialogManager");
            DialogManager = dialogue.GetComponent<DialogManager>();
            
                if (isStartFirst)
                {
                    isRead.isDone = true;
                    StartDialogs();

                }
            }
        }
        else
        {
            if (dialogue == null)
            {
                dialogue = GameObject.FindWithTag("DialogManager");
                DialogManager = dialogue.GetComponent<DialogManager>();

                if (isStartFirst)
                {
                    StartDialogs();
                }
            }
        }
    }
    public void StartDialogs()
    {
        DialogManager.UnityAction = null;
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
        isStartFirst = false;
    }
    public void TurnScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneToLaod, LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLaod));
        };
        Debug.Log("trun");
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
