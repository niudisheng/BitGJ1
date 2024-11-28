using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : NPCInteractor
{
    private void Awake()
    {
        
    }

    public void OnInteract1()
    {
        NPCManager.ChangeInteraction(itemData);
    }
}
