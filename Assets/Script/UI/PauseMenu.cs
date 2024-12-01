using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    public void BackToGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void ExitGame()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
