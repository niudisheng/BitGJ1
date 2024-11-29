using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemChangeSpriteWithoutPlayer : NPCInteractor
{
    public List<Sprite> sprites;
    private int currentIndex = 0;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnClick += OnInteract1;

    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
    public void OnInteract1()
    {
        itemData.isCompleted = true;
        if (currentIndex < sprites.Count - 1)
        {
            spriteRenderer.sprite = sprites[++currentIndex];

        }
    }
}
