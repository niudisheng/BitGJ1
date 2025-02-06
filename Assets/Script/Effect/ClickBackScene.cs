using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBackScene : MonoBehaviour
{
    public string backSceneName;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(backSceneName, LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(backSceneName));
                NewPlayer.instance.GetComponent<Transform>().position = SceneLoadManager.instance.position;
                NewPlayer.instance.gameObject.SetActive(true);
            };
        }
    }
}