using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private List<GameMemento> saves = new List<GameMemento>(); // 存档列表

    // 保存游戏状态
    public void SaveGame(GameMemento memento)
    {
        saves.Add(memento);
        Debug.Log("Game saved!");
    }

    // 加载最近一次存档
    public GameMemento LoadLastSave()
    {
        if (saves.Count > 0)
        {
            Debug.Log("Game loaded!");
            return saves[saves.Count - 1]; // 返回最后一个存档
        }

        Debug.LogWarning("No saves available!");
        return null;
    }

    // 删除所有存档
    public void ClearSaves()
    {
        saves.Clear();
        Debug.Log("All saves cleared!");
    }
}