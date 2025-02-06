using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnInScene : MonoBehaviour
{
    public string sceneName;
    public Vector3 position;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            NewPlayer.instance.transform.position = position;
        };
        Debug.Log("trun");
    }
}