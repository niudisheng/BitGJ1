using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetItemDis : ItemToDescption
{
    public BoolSO isNotLock;
    public override void OnInteract1()
    {
        if (isNotLock.isDone)
        {
            SoundManager.instance.PlayEffect(itemData.name);
            if (dialogue == null)
            {
                dialogue = GameObject.FindWithTag("DialogManager");
                DialogManager = dialogue.GetComponent<DialogManager>();
                descption = DialogManager.descption;
                asset = DialogManager.description;
                assetName = DialogManager.itemName;
                Sprite = DialogManager.Image;
            }
            asset.fontSize = 36;
            descption.SetActive(true);
            asset.text = itemData.introduction;
            Sprite.sprite = itemData.itemImage;
            assetName.text = itemData.itemName;
        }

    }
}
