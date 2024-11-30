using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Record : MonoBehaviour
{
    public GameObject bag;
    public BoolSO isRecord;
    private void Awake()
    {
        if (isRecord.isDone)
        {
            bag.SetActive(true);
            Destroy(gameObject);
        }
    }
}
