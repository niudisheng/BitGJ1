using UnityEngine;
using UnityEngine.UIElements;

public class menu : MonoBehaviour
{
    public UIDocument uiDocument; 
    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        uiDocument.rootVisualElement.Q<Button>("Start").clicked += () => Play();
        uiDocument.rootVisualElement.Q<Button>("Exit").clicked += () => Play();
    }
    
    void Play()
    {
        SceneLoadManager.LoadScene("Game");
        // SceneLoadManager.UnloadScene();
    }

    void Quit()
    {
        Application.Quit();
    }
}
