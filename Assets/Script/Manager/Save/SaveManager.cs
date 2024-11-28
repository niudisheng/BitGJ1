using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveManager : MonoBehaviour
{
    // private List<GameMemento> saves = new List<GameMemento>(); // 存档列表
    static public SaveManager instance;
    public int currentIndex; // 当前存档索引
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        currentIndex = FileSaveManager.GetSaveCount() - 1; // 更新当前存档索引
    }

    // 保存游戏状态
    public void SaveGame(GameMemento save)
    {
        FileSaveManager.SaveToFile(save, currentIndex + 1);
    }
    // 加载最近一次存档
    public GameMemento LoadSave(int index)
    {
        return FileSaveManager.LoadFromFile(index);
    }
    
    public void ClearSaves(int index)
    {
        FileSaveManager.DeleteSave(index);
    }
}


public class FileSaveManager
{
    //TODO: 没有进行二进制序列化，导致存档体积过大，需要优化
    // 保存到文件
    public static void SaveToFile(GameMemento memento,int index)
    {
        string savePath = Application.streamingAssetsPath + $"/save{index}.json";
        string json = JsonUtility.ToJson(memento, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Game saved to file: {savePath}");
    }

    // 从文件加载
    public static GameMemento LoadFromFile(int index)
    {
        string savePath = Application.streamingAssetsPath + $"/save{index}.json";
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
    // 获取存档数量
    public static int GetSaveCount()
    {
        string savesDirectory = Path.Combine(Application.streamingAssetsPath, "");
        int saveCount = 0;
        // Debug.Log(savesDirectory);
        try
        {
            // 获取所有子目录
            string[] directories = Directory.GetFiles(savesDirectory, "save*.json");
            saveCount = directories.Length;
            
        }
        catch (Exception e)
        {
            Debug.LogError($"Error getting save count: {e.Message}");
        }

        return saveCount;
    }
    // 删除存档
    public static bool DeleteSave(int index)
    {
        string saveDirectory = Application.streamingAssetsPath + $"/save{index}.json";
        
        if (Directory.Exists(saveDirectory))
        {
            try
            {
                Directory.Delete(saveDirectory, true); // 删除目录及其所有内容
                Debug.Log($"Save directory deleted: {saveDirectory}");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Error deleting save directory: {e.Message}");
                return false;
            }
        }
        else
        {
            Debug.LogWarning("Save directory does not exist!");
            return false;
        }
    }
}