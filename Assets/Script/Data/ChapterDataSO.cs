using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Chapter Data", menuName = "Data/Chapter Data")]
public class ChapterDataSO : MonoBehaviour
{
    public List<GameObject> npcList;
    public int chapterNumber;
    public Dictionary<GameObject, bool> itemCheckDict;

    public ChapterDataSO()
    {
        foreach (GameObject npc in npcList)
        {
            itemCheckDict.Add(npc, false);
        }
        
    }

}
