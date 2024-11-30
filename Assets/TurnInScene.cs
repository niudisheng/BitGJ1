using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnInScene : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        };
        Debug.Log("trun");
    }
}