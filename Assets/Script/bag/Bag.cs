using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bag : MonoBehaviour
{
    public static Bag instance;

    private void Start()
    {
       instance = this; 
    }
    
    public List<ItemSO> bagItems;
    public List<ItemToDisplay> bagItemPrehabs;
    public List<Image> bagImages;
    public TMP_Text bagText;
    public ItemToDisplay bagItemPrehab;
    public ItemSO bagItem;
    public Texture2D mouse;
    public bool isUse;
    public GameObject bag;

    private void Update()
    {
        if (isUse&Input.GetMouseButtonDown(0))
        {
            isUse = false;
            Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);
            bagItem = null;
            bagText.text = "";
            mouse = null;
        }
    }

    public void AddBagItems(ItemSO item,ItemToDisplay ItemPrefab)
    {
        Debug.Log(item.name);
        bagItems.Add(item);
        bagItemPrehabs.Add(ItemPrefab);
        for (int i = 0; i < bagImages.Count; i++)
        {
            if (bagImages[i].sprite == null)
            {
                bagImages[i].sprite = item.itemImage;
                return;
            }
        }
    }

    public void AddBagItems(ItemSO item)
    {
        Debug.Log(item.name);
        bagItems.Add(item);
        bagItemPrehabs.Add(null);
        for (int i = 0; i < bagImages.Count; i++)
        {
            if (bagImages[i].sprite == null)
            {
                bagImages[i].sprite = item.itemImage;
                return;
            }
        }
    }
    public void DescriptItems(int i)
    {
        bagItem = bagItems[i];
        bagItemPrehab = bagItemPrehabs[i];
        bagText.text = bagItem.introduction;
    }

    public void ClickItem(int i)
    {
        if (bagItems[i]!=null)
        {
            DescriptItems(i);
        }
    }

    public void UseItem()
    {
        isUse = true;
        mouse = bagItem.itemImage.texture;
        //Cursor.SetCursor(mouse,Vector2.zero, CursorMode.Auto);
        if (bagItemPrehab != null)
        {
            bagItemPrehab.UseItem();
        }
        else
        {
            UIManager.instance.CannotUse();
        }
        bag.SetActive(false);
    }
}
