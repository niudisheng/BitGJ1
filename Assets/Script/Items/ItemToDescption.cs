using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 2.点击出现物品介绍但是无法进入其他场景
/// </summary>
public class ItemToDescption : NPCInteractor
{
    
    private void Awake()
    {
        base.Awake();
        
        OnClick += OnInteract1;
        
    }

    public void OnInteract1()
    {
        //TODO: 调用Dialog
    }
    
}
