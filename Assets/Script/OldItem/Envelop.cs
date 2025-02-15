using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Envelop : NPCInteractor
{
    private void Awake()
    {
        OnClick += GoDestroy;
    }
    public void GoDestroy()
    {
        Destroy(gameObject);
    }
}
