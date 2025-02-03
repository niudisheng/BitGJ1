using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public static Mouse instance;

    private void Start()
    {
        instance = this;
    }

    public Texture2D cursor;
    public void ChangeMuouse(Texture2D mouse)
    {
        Cursor.SetCursor(mouse,Vector2.zero, CursorMode.Auto);
    }
}
