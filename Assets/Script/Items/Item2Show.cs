using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item2Show : BaseItem
{
    public Text itemDescription;
    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Item2Show OnPointerEnter");
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
    }
}
