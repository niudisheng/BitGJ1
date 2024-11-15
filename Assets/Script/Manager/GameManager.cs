using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1f;
    public GameManager instance;
    public void Awake()
    {
        
    }

    static public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }
    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        Time.timeScale = 0.1f;
    }

}
