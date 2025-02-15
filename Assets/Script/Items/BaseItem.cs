using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BaseItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public UnityEvent afterOnPointerHandler;
    public float offSet;
    private Collider2D collider;
    public UnityAction OnClick;
    public ItemSO itemData;
    protected Vector3 originalScale;
    public float distance;
    protected virtual void Awake()
    {
        collider = GetComponent<Collider2D>();
        itemData.InitItem();
    }

    private void Start()
    {
        originalScale = this.transform.localScale;
        if(originalScale == Vector3.zero)
            originalScale=Vector3.one;
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (Mathf.Abs(this.transform.position.x - NewPlayer.instance.transform.position.x-offSet)<distance)
        {
            this.transform.localScale = originalScale* 1.2f; 
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = originalScale* 1.0f;
        
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Mathf.Abs(this.transform.position.x - NewPlayer.instance.transform.position.x-offSet)<distance)
        {
            OnClick?.Invoke();
            afterOnPointerHandler?.Invoke();
        } 

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        // 绘制从起点到终点的线
        Gizmos.DrawLine(transform.position - Vector3.right * distance-new Vector3(offSet,0,0), transform.position + Vector3.right * distance-new Vector3(offSet,0,0)); 
    }
}
