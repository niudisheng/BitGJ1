using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO" ,menuName = "Data/ItemData")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemCounter;
    public string introduction;
}
