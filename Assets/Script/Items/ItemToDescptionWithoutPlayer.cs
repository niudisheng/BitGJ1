using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToDescptionWithoutPlayer : ItemToDescption
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
