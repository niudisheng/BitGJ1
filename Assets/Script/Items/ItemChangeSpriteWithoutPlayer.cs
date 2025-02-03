using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemChangeSpriteWithoutPlayer : NPCInteractor
{
    public bool isCircle;
    public List<Sprite> sprites;
    [HideInInspector]public int currentIndex = 0;
    protected SpriteRenderer spriteRenderer;
    private void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnClick += OnInteract1;

    }

    public virtual void OnInteract1()
    {
        itemData.isCompleted = true;
        if (currentIndex < sprites.Count - 1)
        {
    
            spriteRenderer.sprite = sprites[++currentIndex];

        }
        if (isCircle& currentIndex == sprites.Count-1)
        {
            spriteRenderer.sprite = sprites[0];
            currentIndex = 0;
        }
    }
}
