using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO" ,menuName = "Data/ItemData")]
public class ItemSO : ScriptableObject
{
    public ChapterDataSO chapterData;
    public string itemName;
    public Sprite itemImage;
    public int itemCounter;
    public string introduction;
    public bool isUnlocked=true;
    public bool isCompleted=false;

    public void InitItem(string name, Sprite image)
    {
            itemImage = image;
            chapterData.AddNpc(this);
            itemName = name;
            this.name = name;

    }
}
