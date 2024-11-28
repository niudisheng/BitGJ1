using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// 可交互的物品
/// </summary>
public class NPCInteractor : BaseItem
{
    public bool canInteract = false;
    

    protected virtual void Update()
    {
            if (canInteract)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null&hit.collider.CompareTag("NPC"))
                    {
                        OnClick?.Invoke();
                    }
                }
            }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }
    //检测玩家
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    
}
