using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable] // 标记为可序列化，用于后续保存到文件
public class GameMemento
{
    private Vector2 playerPosition; // 玩家位置
    public string sceneName; // 当前场景
    //道具列表，解谜数据，道具栏状态
    private ChapterDataSO chapterData; // 当前章节数据
    // 构造函数，用于初始化状态
    public GameMemento(Vector3 position,string scene,ChapterDataSO chapterData)
    {
        playerPosition = position;
        sceneName = scene;
        this.chapterData = chapterData;
        
    }
}