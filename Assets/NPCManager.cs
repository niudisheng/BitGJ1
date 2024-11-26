using UnityEngine;

public class NPCManager : MonoBehaviour
{
    
    static public ChapterDataSO chapterData;
    
    private GameObject startInteraction;
    public string startName;

    private void Awake()
    {
        //AddInteraction();
        //TrunInteractionOn(startName);
    }
    
    //这个函数其实不需要，可以直接在Inspector中设置初始的交互对象
    public void TrunInteractionOn(string name)
    {
        startInteraction.SetActive(true);
    }
    public void AddInteraction()
    {
        foreach (GameObject gameObject in chapterData.npcList)
        {
            // imageDir.Add(gameObject.name, gameObject);
        }
    }
    
    //物品回调，改变自己的交互结果
    static public void ChangeInteraction(GameObject item)
    {
        chapterData.itemCheckDict[item] = true;
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
