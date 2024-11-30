using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Descriptions : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
        }
    }
}
