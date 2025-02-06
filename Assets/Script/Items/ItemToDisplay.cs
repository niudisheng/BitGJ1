using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 就是在一级或者二级界面中可以直接获取的物品，同时触发介绍的
/// </summary>
public class ItemToDisplay : NPCInteractor
{
    public BoolSO isGot;
    public DoubleSO progress;
    public ObjectEventSO AddTOItemDisplay;
    private void Awake()
    {
        if (isGot.isDone)
        {
            gameObject.SetActive(false);
        }
        else
        {
            base.Awake();
            OnClick += OnInteract1;
        }

        
    }

        public void OnInteract1()
    {
        AddTOItemDisplay.RaiseEvent(this.itemData,this);
        progress.progress++;
        isGot.isDone = true;
        Debug.Log("OnPointerClick");
        Bag.instance.AddBagItems(itemData);
        Destroy(gameObject);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    } 
}
