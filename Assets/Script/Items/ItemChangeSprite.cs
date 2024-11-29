using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 点击某个格子切换状态（左到右）
/// </summary>
public class ItemChangeSprite : NPCInteractor
{
    public int currentIndex = 0;
    public SpriteRenderer spriteRenderer;
    [Header("需要切换的图片")]
    public List<Sprite> sprites;
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
    }
    
}
