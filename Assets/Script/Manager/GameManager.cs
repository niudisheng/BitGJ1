using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Transform playerTransform; // 玩家位置
    [Header("广播事件")]
    public ObjectEventSO LoadGameEvent; // 加载游戏事件
    public List<ChapterDataSO> chapters; // 所有章节数据
    public ChapterDataSO currentChapter; // 当前章节数据

    public bool isReady = false;


    [ContextMenu("CreateMemento")]
    // 创建备忘录（保存游戏状态）
    public GameMemento CreateMemento()
    {
        Vector3 playerPosition1 = playerTransform.position;
        GameMemento memento = new GameMemento(playerPosition1,SceneLoadManager.CurrentSceneName,currentChapter);
        SaveManager.instance.SaveGame(memento); // 保存游戏状态
        return memento;
    }
    [ContextMenu("Try Load")]
    public void TryLoad()
    {
        GameMemento memento = SaveManager.instance.LoadSave(0); // 加载游戏状态
        LoadMemento(memento); // 恢复游戏状态
            
    }
    
    // 从备忘录中恢复游戏状态
    public void LoadMemento(GameMemento memento)
    {
        Debug.Log("Game state restored!");
        LoadGameEvent.RaiseEvent(null,this); // 广播加载游戏事件
    }
    
    static public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }
    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        Time.timeScale = 0.1f;
    }

    public void OnloadGame()
    {
        StartCoroutine(updateChapter());
    }

    [ContextMenu("Move To Next Chapter")]
    public void MoveToNextChapter()
    {
        isReady = true;
    }

    public IEnumerator updateChapter()
    {
        
        foreach (var chapter in chapters)
        {
            currentChapter = chapter;
            yield return  new WaitWhile(CheckToNextChapter);
            isReady = false;
            
        }
    }
    
    
    /// <summary>
    /// 结果为true时被卡住，为false时，执行下一步
    /// </summary>
    /// <returns></returns>
    public bool CheckToNextChapter()
    {
        
        //TODO: 需要优化逻辑，当前只是简单实现，后续需要根据章节的条件判断是否进入下一章节
        if (currentChapter.CheckAllItem() &&isReady)
        {
            return false;
        }
        isReady = false;
        return true;
    }
}