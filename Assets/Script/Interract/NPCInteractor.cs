using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteractor : MonoBehaviour
{
    public UnityEvent OnInteract;
    public PlayerInteractor PlayerInteractor;
    private void Update()
    {
        if (PlayerInteractor != null)
        {
            if (PlayerInteractor.canInteract)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null)
                    {
                        OnInteract?.Invoke();
                    }
                }
            }
        }
    }
}
