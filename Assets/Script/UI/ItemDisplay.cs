
using System.Collections.Generic;
using UnityEngine;
public class ItemDisplay : MonoBehaviour
{
    public GameObject itemPrefab;
    private const int spaceing = 89;
    
    public List<ItemSO> items;
    
    private Vector3 getPosition(int index)
    {
        Vector3 startPos = itemPrefab.transform.localPosition;
        Vector3 newPos = startPos + new Vector3(spaceing * index,0, 0);
        // Debug.Log("Start position: " + startPos);
        // Debug.Log("New position: " + newPos);
        return newPos;
    }
    
    public void AddItem(object itemData1)
    {
        Debug.Log("hi");
        ItemSO itemData = itemData1 as ItemSO;
        Debug.Log("Adding item: " + itemData.name);
        Bag.instance.AddBagItems(itemData);
        items.Add(itemData);
        int index = items.Count-1;
        GameObject item = Instantiate(itemPrefab, transform);
        item.transform.localPosition = getPosition(index);
        item.GetComponentInChildren<Item2Show>().Init(itemData);
        item.SetActive(true);
        
    }

    public void CheckItem(object itemData1)
    {
        
    }

}
