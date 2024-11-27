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
}