using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public StartDialog Dialog1;
    public StartDialog Dialog2;
    public StartDialog Dialog3;
    public bool isLeather;
    public bool isKey;
    public double total;
    public DoubleSO progress;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(isKey)
        {
            if (progress.progress >= total * 0.8&!isLeather)
            {
                Dialog1.StartDialogs();
            }
            else if (progress.progress < total *0.8)
            {
                Dialog2.StartDialogs();
            }
            else if(progress.progress >= total * 0.8&isLeather)
            {
                 Dialog3 .StartDialogs();
            }
        }
    }
}