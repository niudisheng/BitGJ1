using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isDoor3;
    public StartDialog Dialog1;
    public StartDialog Dialog2;
    public StartDialog Dialog3;
    public BoolSO isSpecial;
    public BoolSO isKey;
    public double total;
    public DoubleSO progress;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDoor3)
        {
            if(progress.progress==2)
            {
                Dialog1.StartDialogs();
            }
            else if (progress.progress ==3)
            {
                Dialog2.StartDialogs();
            }
        }
        else if (isKey.isDone)
        {
            if (progress.progress >= total * 0.8&!isSpecial.isDone)
            {
                Dialog2.StartDialogs();
            }
            else if (progress.progress < total *0.8)
            {
                Dialog1.StartDialogs();
            }
            else if(progress.progress >= total * 0.8& isSpecial.isDone)
            {
                 Dialog3 .StartDialogs();
            }
        }
    }
}
