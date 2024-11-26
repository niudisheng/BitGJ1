using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : NPCInteractor
{
    private void OnInteract()
    {
        NPCManager.ChangeInteraction(this.gameObject);
    }
}
