using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemDisplay : MonoBehaviour
{
    [FormerlySerializedAs("testitem")] public GameObject itemPrefab;
    private const int spaceing = 110;
    
    public List<ItemSO> items;
    
    private void setPosition(int index,GameObject item)
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 newPos = startPos + new Vector3(0, spaceing * index, 0);
        item.transform.position = newPos;
    }

    public void DisplayItems()
    {
        for (int index = 0; index < items.Count; index++)
        {
            GameObject item = Instantiate(itemPrefab, transform);
            // item.GetComponent<Item2Show>().itemData = items[index];
            item.GetComponent<Item2Show>().Init(items[index]);
        }
    }

}
