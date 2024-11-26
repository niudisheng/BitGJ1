using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    
    public ChapterDataSO chapterData;
    
    public List<BaseItem> interactions;
    static public NPCManager instance;
    private void Start()
    {
        instance = this;
        AddInteraction();
        
    }
    
    public void AddInteraction()
    {
        foreach (BaseItem item in interactions)
        {
            ItemSO itemData = item.itemData;
            chapterData.AddNpc(itemData);
            ChangeInteraction(itemData,false);
            
        }
    }
    
    //物品回调，改变自己的交互结果
    public void ChangeInteraction(ItemSO item,bool result)
    {
        chapterData.itemCheckDict[item] = result;
    }

    //检查是否完成所有交互
    public bool checkInteraction()
    {
        foreach (bool result in chapterData.itemCheckDict.Values)
        {
            
            if (!result)
            {
                return false;
            }
        }
        return true;
    }
}
