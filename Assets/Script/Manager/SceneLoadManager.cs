using System.Threading.Tasks;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    static public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }

    static public void UnloadScene()
    {   
        Debug.Log("Unload Scene "+SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
