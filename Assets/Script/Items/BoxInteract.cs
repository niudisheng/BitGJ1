using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteract : NPCInteractor
{
    public SpriteRenderer SpriteRenderer;
    public Sprite box1;
    public Sprite box2;
    public Sprite box3;
    public Sprite box4;
    public int clickCount = 0;
    public void OnBoxClick()
    {
        clickCount++;
    }
    public void TrunSprite()
    {
        switch (clickCount)
        {
            case 0:
                SpriteRenderer.sprite = box1;
                break;
            case 1:
                SpriteRenderer.sprite = box2;
                break;
            case 2:
                SpriteRenderer.sprite = box3;
                break;
            case 3:
                SpriteRenderer.sprite = box4;
                break;
        }

    }
    protected override void Awake()
    {
        
    }
    //protected override void Update()
    //{
    //    base.Update();
    //    TrunSprite();
    //}
}
