using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Transform playerTransform; // 玩家位置
    [Header("广播事件")]
    public ObjectEventSO LoadGameEvent; // 加载游戏事件
    [ContextMenu("CreateMemento")]
    // 创建备忘录（保存游戏状态）
    public GameMemento CreateMemento()
    {
        Vector3 playerPosition1 = playerTransform.position;
        GameMemento memento = new GameMemento(playerPosition1,SceneLoadManager.CurrentSceneName);
        SaveManager.instance.SaveGame(new GameMemento(playerPosition1,SceneLoadManager.CurrentSceneName)); // 保存游戏状态
        return memento;
    }

    // 从备忘录中恢复游戏状态
    public void RestoreMemento(GameMemento memento)
    {
        Debug.Log("Game state restored!");
        LoadGameEvent.RaiseEvent(memento,this); // 广播加载游戏事件
    }

    // 示例：展示当前状态
    public void ShowState()
    {
        
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
}