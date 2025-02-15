using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Calender : DragItem
{
    public float destroyDistence;
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Sqrt(Mathf.Pow(startPos.x - transform.position.x, 2) + Mathf.Pow(startPos.y - transform.position.y, 2)) > destroyDistence)
        {
            Destroy(gameObject);
        }
        else
        {
            this.transform.position = startPos;
            isDragging = false;
        }
    }
}
