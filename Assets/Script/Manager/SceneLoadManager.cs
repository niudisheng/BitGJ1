using System;
using System.Threading.Tasks;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    static public bool isready = false;
    public GameObject player;
    public Vector3 position;
    public static SceneLoadManager instance;
    private void Start()
    {
        instance = this;

    }

    static public string CurrentSceneName
    {
        get { return SceneManager.GetActiveScene().name; }
    }

    static public GameObject Trans;
    [ContextMenu("LoadScene")]
    public void LoadScene()
    {
        LoadScene(CurrentSceneName);

    }
    
    static public void LoadScene(string sceneName)
    {

        Trans.SetActive(true);
        DelayedAction.instance.StartDelayedAction(0.5f, delegate()
        {
            UnloadScene();
            SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive).completed += (op) =>
            {
                Debug.Log("Scene Loaded");

                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            };
        });
    }
    static public void LoadScene(int index)
    {
        Trans.SetActive(true);
        DelayedAction.instance.StartDelayedAction(0.5f, delegate()
        {
            UnloadScene();
            SceneManager.LoadSceneAsync(index,LoadSceneMode.Additive).completed += (op) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));
            };
        });
        

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

    public void LoadPlayer()
    {
        GameObject P = Instantiate(player, new Vector3(-1.3f,1.4f,0), Quaternion.identity);
        SceneManager.MoveGameObjectToScene(P, SceneManager.GetSceneByName("permanent"));
    }
}
