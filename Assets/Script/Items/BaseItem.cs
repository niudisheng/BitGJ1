using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BaseItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public Collider2D collider;
    public UnityEvent OnClick;
    public ItemSO itemData;

    protected virtual void Awake()
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

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    protected void disable()
    {
        collider.enabled = false;
    }

}
