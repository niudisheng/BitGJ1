using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Notebook : ItemToDescption
{
    public DoubleSO progress;
    public BoolSO isRead;
    public override void OnInteract1()
    {
        if (dialogue == null)
        {
            dialogue = GameObject.FindWithTag("DialogManager");
            DialogManager = dialogue.GetComponent<DialogManager>();
            descption = DialogManager.descption;
            asset = DialogManager.description;
            assetName = DialogManager.itemName;
            Sprite = DialogManager.Image;
        }
        descption.SetActive(true);
        asset.text = itemData.introduction;
        Sprite.sprite = itemData.itemImage;
        assetName.text = itemData.itemName;
        asset.fontSize = 25;
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
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
}
