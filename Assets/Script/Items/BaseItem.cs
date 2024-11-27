using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BaseItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public Collider2D collider;
    public UnityEvent OnItemClick;
    public ItemSO itemData;

    protected void Awake()
    {
        itemData.InitItem();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemClick.Invoke();
    }

    protected void disable()
    {
        collider.enabled = false;
    }

}
