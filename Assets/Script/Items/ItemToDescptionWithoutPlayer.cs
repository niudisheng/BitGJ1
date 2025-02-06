using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToDescptionWithoutPlayer : ItemToDescption
{
    public DoubleSO progress;
    public BoolSO isRead;
    public override void OnInteract1()
    {
        base.OnInteract1();
        if (!isRead.isDone)
        {
            isRead.isDone = true;
            progress.progress++;
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
