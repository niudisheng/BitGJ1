using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// 2.点击出现物品介绍但是无法进入其他场景
/// </summary>
public class ItemToDescption : NPCInteractor
{
    public GameObject dialogue;
    public DialogManager DialogManager;
    public GameObject descption;
    public TMP_Text asset;
    public TMP_Text assetName;
    public Image Sprite;
    private void Awake()
    {
        base.Awake();
        
        OnClick += OnInteract1;
        
        
    }
    public virtual void OnInteract1()
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
