using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public BoolSO isGet;
    public ItemToDisplay ItemToDisplay;
    protected virtual void Awake()
    {
        ItemToDisplay.OnClick += GotItem;
    }
    public void GotItem()
    {
        isGet.isDone = true;
    }
}
