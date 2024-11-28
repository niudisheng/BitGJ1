using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    public List<GameObject> uiList;
    Dictionary<UIType,GameObject> uiDictionary=new();
    private void Awake()
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            UIType uiType = (UIType)i;
            uiDictionary.Add(uiType,uiList[i]);
        }
    }

    public void ShowCanvas(bool show)
    {
        canvas.SetActive(show);
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
        }
        GameObject ui = uiDictionary[uiType];
        ui.SetActive(active);
    }
}
