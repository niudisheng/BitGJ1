using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Chapter Data", menuName = "Data/Chapter Data")]
public class ChapterDataSO : ScriptableObject
{
    public List<ItemSO> npcList=new ();
    public int chapterNumber;
    public Dictionary<ItemSO, bool> itemCheckDict=new ();
    public void AddNpc(ItemSO npc)
    {
        npcList.Add(npc);
        itemCheckDict.Add(npc, false);
    }

    public void Reset()
    {
        itemCheckDict.Clear();
        npcList.Clear();
    }
}
