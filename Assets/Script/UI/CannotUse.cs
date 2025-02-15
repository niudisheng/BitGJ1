using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotUse : MonoBehaviour
{
    public bool isActive;
    
    private void Update()
    {
        isActive = gameObject.activeSelf;
        if (isActive)
        {
            Invoke("Disappear",1f);
        }
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
        isActive = false;
    }
}
