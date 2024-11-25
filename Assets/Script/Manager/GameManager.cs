using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector3 playerPosition; // 玩家位置
    public Scene currentScene;     // 当前场景
    [Header("广播事件")]
    public ObjectEventSO LoadGameEvent; // 加载游戏事件
    // 创建备忘录（保存游戏状态）
    public GameMemento CreateMemento()
    {
        return new GameMemento(playerPosition,currentScene);
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