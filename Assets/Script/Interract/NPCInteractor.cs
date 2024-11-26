using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractor : BaseItem
{
    public bool canInteract = false;
    protected UnityAction OnInteract;
    private void Update()
    {
            if (canInteract)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null&hit.collider.CompareTag("NPC"))
                    {
                        OnInteract?.Invoke();
                    }
                }
            }
    }
    //¼ì²âÍæ¼Ò
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
