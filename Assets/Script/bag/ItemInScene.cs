using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInScene : MonoBehaviour
{
    public ItemSO Item;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()
    {
        if (playerInventory.itemList.Contains(Item))
        {
            playerInventory.itemList.Add(Item);
        }
        else
        {
            Item.itemCounter++;
        }
    }
}
