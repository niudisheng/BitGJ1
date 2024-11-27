using UnityEngine;

public class NPCManager : MonoBehaviour
{
    static public ChapterDataSO chapterData;

    public void AddInteraction()
    {
        foreach (ItemSO item in chapterData.npcList)
        {
            // imageDir.Add(gameObject.name, gameObject);
        }
    }
}
    
    
