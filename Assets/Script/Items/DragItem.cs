using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        startPos = this.transform.position;
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = startPos;
        isDragging = false;
        
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
                
                return true;
            }
        }
        return false;
    }

    
}