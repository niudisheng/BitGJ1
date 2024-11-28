using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 就是在一级或者二级界面中可以直接获取的物品，同时触发介绍的
/// </summary>
public class ItemToDisplay : NPCInteractor
{
    public ObjectEventSO AddTOItemDisplay;
    private void Awake()
    {
        base.Awake();
        
        OnClick += OnInteract1;
        
    }

    public void OnInteract1()
    {
        Debug.Log("ItemToDisplay Interact");
        AddTOItemDisplay.RaiseEvent(this.itemData,this);
    }
    
}
