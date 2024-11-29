using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Chapter Data", menuName = "Data/Chapter Data")]
public class ChapterDataSO : ScriptableObject
{
    public List<ItemSO> npcList=new ();
    public int chapterIndex;
    
    // public Dictionary<ItemSO, bool> itemCheckDict=new ();
    /// <summary>
    /// 这个函数给NPC调用，把它自己加进来
    /// </summary>
    /// <param name="npc"></param>
    public void AddNpc(ItemSO npc)
    {
        if (npcList.Contains(npc))
        {
            return;
        }
        npcList.Add(npc);
        
    }

    public bool CheckAllItem()
    {
        foreach (var item in npcList)
        {
            if (!item.isCompleted)
            {
                return false;
            }
        }
        return true;
    }
    public float CheckItemRate()
    {
        float count = 0;
        foreach (var item in npcList)
        {
            if (!item.isCompleted)
            {
                count++;
            }
        }
        return (float)count / npcList.Count;
    }

    public void Reset()
    {
        npcList.Clear();
    }
}
