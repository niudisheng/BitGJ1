using System.Collections;
using System.Collections.Generic;
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
