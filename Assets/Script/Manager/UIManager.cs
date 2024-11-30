using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    public List<GameObject> uiList;
    Dictionary<UIType,GameObject> uiDictionary=new();
    public GameObject trans;
    static public UIManager instance;
    private void Awake()
    {
        SceneLoadManager.Trans = trans;
        if (instance == null)
        {
            return;
        }
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            UIType uiType = (UIType)i;
            uiDictionary.Add(uiType,uiList[i]);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            HideAllUI();
        }
    }
    public void ShowAllUI()
    {
        setUIActive(UIType.All,true);
    }

    public void HideAllUI()
    {
        setUIActive(UIType.All,false);
        
    }

    public void setUIActive(UIType uiType,bool active)
    {
        if (uiType == UIType.All)
        {
            foreach (var UI in uiList)
            {
                UI.SetActive(active);
            }
            return;
        }
        GameObject ui = uiDictionary[uiType];
        ui.SetActive(active);
    }

    public void OnChangeDescription(object obj)
    {
        string description = (string)obj;
        Text text = uiDictionary[UIType.descption].GetComponentInChildren<Text>();
        text.text = description;
        
    }
}
