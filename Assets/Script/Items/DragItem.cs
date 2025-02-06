using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Sprite icon;
    public bool isDragging = false;
    public Vector3 offSetPos;
    public Vector2 startPos;
    private Vector2 endPos;
    private DragContainer dragContainer;
    private Collider2D collider;
    

    private void Awake()
    {
        dragContainer = GetComponentInParent<DragContainer>();
        collider = GetComponent<Collider2D>();
        collider.enabled = true;
    }

    //拖拽中
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        //非攻击卡拖拽
        Vector3 screenPos=new(Input.mousePosition.x,Input.mousePosition.y,10);
        Vector3 worldPos=Camera.main.ScreenToWorldPoint(screenPos);
        this.transform.position = worldPos - offSetPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        startPos = this.transform.position;
        isDragging = true;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        bool result = CheckCollision();
        if (result)
        {
            Debug.Log("拖拽成功");
            collider.enabled = false;
            transform.position = dragContainer.endPos;
            return;
        }
        this.transform.position = startPos;
        
        

    }

    private void Update()
    {
        if (isDragging)
        {
            if (Input.GetMouseButtonUp(1))
            {
                this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, 90);
            }
        }
    }

    private bool CheckCollision()
    {
        //pointA为起点，pointB为终点，连成四边形
        float Offset = 0.5f;
        /*
        var hits = Physics2D.OverlapAreaAll(new Vector2(endPos.x - Offset,endPos.y - Offset), new Vector2(endPos.x + Offset, endPos.y + Offset));
        foreach (var hit in hits)
        {
            if (hit != null && hit.gameObject.CompareTag("Container"))
            {
                Debug.Log($"碰撞到物体：{hit.gameObject.name}");
                this.transform.position = hit.transform.position;
                
                return true;
            }
        }*/
        Vector2 relativePos = this.transform.position - dragContainer.endPos;
            
        if (relativePos.magnitude < Offset)
        {
            return true;
        }
        return false;
    }

    
}