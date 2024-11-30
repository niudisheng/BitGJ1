using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BaseItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    private Collider2D collider;
    public UnityAction OnClick;
    public ItemSO itemData;
    protected Vector3 originalScale;
    protected virtual void Awake()
    {
        collider = GetComponent<Collider2D>();
        itemData.InitItem(this.gameObject.name,this.GetComponent<SpriteRenderer>().sprite);
    }

    private void Start()
    {
        originalScale = this.transform.localScale;
        if(originalScale == Vector3.zero)
            originalScale=Vector3.one;
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = originalScale* 1.2f;
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = originalScale* 1.0f;
        
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

}
