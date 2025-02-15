using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildKey : GetItem
{
    public GameObject box;
    public Sprite box4;
    protected override void Awake()
    {
        ItemToDisplay.OnClick += GotItem;
    }
    private void Update()
    {
        SpriteRenderer spriteRenderer = box.GetComponent<SpriteRenderer>();
        if(spriteRenderer.sprite == box4)
        {
            box.SetActive(false);
        }
    }
}
