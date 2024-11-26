using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveManager : MonoBehaviour
{
    public List<GameMemento> saves = new List<GameMemento>(); // 存档列表
    static public SaveManager instance;
    
    private void Awake()
    {
        instance = this;
    }

    // 保存游戏状态
    public void SaveGame(GameMemento memento)
    {
        saves.Add(memento);
        Debug.Log("Game saved!");
    }

    // 加载最近一次存档
    public GameMemento LoadSave(int index)
    {
        if (index >= saves.Count)
        {
            return null; // 存档不存在
        }

        if (saves.Count > 0)
        {
            Debug.Log("Game loaded!");
            return saves[index - 1]; // 返回最后一个存档
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
    [ContextMenu("Try Save")]
    public void TrySave()
    {
        foreach (var save in saves)
        {
            
            FileSaveManager.SaveToFile(save,saves.IndexOf(save));
        }
    }
}


public class FileSaveManager
{
    

    // 保存到文件
    public static void SaveToFile(GameMemento memento,int index)
    {
        string savePath = Application.streamingAssetsPath + $"/{index}/save.json";
        string json = JsonUtility.ToJson(memento, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Game saved to file: {savePath}");
    }

    // 从文件加载
    public static GameMemento LoadFromFile(int index)
    {
        string savePath = Application.streamingAssetsPath + $"/{index}/save.json";
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            GameMemento memento = JsonUtility.FromJson<GameMemento>(json);
            Debug.Log("Game loaded from file.");
            return memento;
        }

        Debug.LogWarning("No save file found!");
        return null;
    }
}