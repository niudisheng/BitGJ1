using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractor : MonoBehaviour
{
    public bool canInteract = false;
    public UnityEvent OnInteract;
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
