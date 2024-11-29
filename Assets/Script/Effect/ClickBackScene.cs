using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBackScene : MonoBehaviour
{
    public string backSceneName;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneLoadManager.LoadScene(backSceneName);
        }
    }
}
