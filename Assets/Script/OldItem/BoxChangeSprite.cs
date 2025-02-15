using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChangeSprite : ItemChangeSpriteWithoutPlayer
{
    public PolygonCollider2D PolygonCollider2D;
    public override void OnInteract1()
    {
        itemData.isCompleted = true;
        if (currentIndex < sprites.Count - 1)
        {
            PolygonCollider2D.gameObject.SetActive(false);
            spriteRenderer.sprite = sprites[++currentIndex];

        }
        if (isCircle & currentIndex == sprites.Count - 1)
        {
            spriteRenderer.sprite = sprites[0];
            currentIndex = 0;
        }
    }
}
