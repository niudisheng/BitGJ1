using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBox : MonoBehaviour
{
    public BoolSO BoolSO;
    public List<GameObject> gameObjects = new List<GameObject>();
    public List<Sprite> nowSprite = new List<Sprite>();
    public List<Sprite> answer = new List<Sprite>();
    public ObjectEventSO GoNextSceneEvent;
    private void Update()
    {
        nowSprite[0] = gameObjects[0].GetComponent<SpriteRenderer>().sprite;
        nowSprite[1] = gameObjects[1].GetComponent<SpriteRenderer>().sprite;
        nowSprite[2] = gameObjects[2].GetComponent<SpriteRenderer>().sprite;
        nowSprite[3] = gameObjects[3].GetComponent<SpriteRenderer>().sprite;
        if (nowSprite[0] == answer[0] & nowSprite[1] == answer[1] & nowSprite[2] == answer[2] & nowSprite[3] == answer[3]&!BoolSO.isDone)
        {
            Debug.Log("win");
            BoolSO.isDone = true;
            GoNextSceneEvent.RaiseEvent("CodeBox2", this);

        }

    }
}
