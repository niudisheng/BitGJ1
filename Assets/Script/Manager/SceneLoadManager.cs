using System;
using System.Threading.Tasks;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    static public string CurrentSceneName
    {
        get { return SceneManager.GetActiveScene().name; }
    }

    [ContextMenu("LoadScene")]
    public void LoadScene()
    {
        LoadScene(CurrentSceneName);
    }

    static public void LoadScene(string sceneName)
    {
        UnloadScene();
        //TODO: 加入场景加载进度条
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        };
    }
    static public void LoadScene(int index)
    {
        UnloadScene();
        
        //TODO: 加入场景加载进度条
        SceneManager.LoadSceneAsync(index,LoadSceneMode.Additive).completed += (op) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
        };

    }
    

    static public void LoadSceneInMemento(object memento)
    {
        GameMemento memento1 = (GameMemento)memento;
        string sceneName = memento1.sceneName;
        LoadScene(sceneName);
    }

    static public void UnloadScene()
    {   
        Debug.Log("Unload Scene "+SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
