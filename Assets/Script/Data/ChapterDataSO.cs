using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Chapter Data", menuName = "Data/Chapter Data")]
public class ChapterDataSO : ScriptableObject
{
    public List<GameObject> npcList;
    public int chapterNumber;
    public Dictionary<GameObject, bool> itemCheckDict;

    public void AddNpc(GameObject npc)
    {
        
    }

}
