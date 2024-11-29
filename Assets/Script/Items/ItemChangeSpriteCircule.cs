using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChangeSpriteCircule : ItemChangeSpriteWithoutPlayer
{
    public override void OnInteract1()
    {
        itemData.isCompleted = true;
        if (currentIndex < sprites.Count - 1)
        {
            spriteRenderer.sprite = sprites[++currentIndex];
        }
        
    }
}
