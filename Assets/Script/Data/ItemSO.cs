using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO" ,menuName = "Data/ItemData")]
public class ItemSO : ScriptableObject
{
    public ChapterDataSO chapterData;
    public string itemName;
    public Sprite itemImage;
    public int itemCounter;
    public string introduction;
    public bool isUnlocked;
    public bool isCompleted=false;
}
