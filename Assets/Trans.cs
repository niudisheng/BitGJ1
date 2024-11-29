using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Trans : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 mid;
    private Vector3 endPos;

    

    private void OnEnable()
    {
        startPos = transform.position;
        mid = startPos + new Vector3(-1940, 0,0);
        endPos = startPos + new Vector3(-1940*2, 0,0);
        Move();
    }

    private void Move()
    {
        transform.DOMove(mid, 0.5f).OnComplete(
            delegate()
            {
                transform.DOMove(endPos, 0.5f).OnComplete(() => this.gameObject.SetActive(false));
                // SceneLoadManager.isready = true;
            }
                
                
            );
    }

    private void OnDisable()
    {
        transform.position = startPos;
        
    }
}
