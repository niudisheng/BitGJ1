using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : BaseItem,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Sprite icon;
    public bool isDragging = false;
    public Vector2 startPos;
    private Vector2 endPos;
    
    //拖拽中
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //非攻击卡拖拽
        Vector3 screenPos=new(Input.mousePosition.x,Input.mousePosition.y,10);
        Vector3 worldPos=Camera.main.ScreenToWorldPoint(screenPos);
        this.transform.position = worldPos;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position;
        isDragging = true;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        bool result = CheckCollision();
        if (result)
        {
            
        }
        //回到原来的位置
        else
        {
            this.transform.position = endPos;
            isDragging = false;
        }
        
    }
    
    private bool CheckCollision()
    {
        //pointA为起点，pointB为终点，连成四边形
        float Offset = 10f;
        var hits = Physics2D.OverlapAreaAll(new Vector2(endPos.x - Offset,endPos.y - Offset), new Vector2(endPos.x + Offset, endPos.y + Offset));
        foreach (var hit in hits)
        {
            if (hit != null && hit.gameObject.CompareTag("Container"))
            {
                Debug.Log($"碰撞到物体：{hit.gameObject.name}");
                this.transform.position = hit.transform.position;
                disable();
                return true;
            }
        }
        return false;
    }

    
}