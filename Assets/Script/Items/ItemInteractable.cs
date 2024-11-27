using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 有回调，需要计数的交互物品
/// </summary>
public class ItemInteractable : NPCInteractor
{
    private void Awake()
    {
        OnInteract += OnInteract1;
    }

    public void OnInteract1()
    {
        itemData.isCompleted = true;
    }
}
