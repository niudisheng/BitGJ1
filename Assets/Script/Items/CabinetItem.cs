using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetItem : ItemChangeSprite
{
    public BoolSO isLock;
    private void Awake()
    {
        if (isLock.isDone)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
        }
        base.Awake();
    }
    public override void OnInteract1()
    {
        itemData.isCompleted = true;
        if (currentIndex < sprites.Count - 1 &!isLock.isDone)
        {
            spriteRenderer.sprite = sprites[++currentIndex];

        }
    }
}
