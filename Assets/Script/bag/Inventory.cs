using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInventory",menuName ="Inventory/ItemInventory")]
public class Inventory : ScriptableObject
{
    public List<ItemSO> itemList = new List<ItemSO>();
}
