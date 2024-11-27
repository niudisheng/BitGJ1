using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//泛型的使用
public class BaseEventSO<T> : ScriptableObject
{   
    //用于inspector面板显示的事件描述
    [TextArea]
    public string description;
    //事件发生时触发的事件,这个方法由listener传递，实际就是传入的response
    public UnityAction<T> OnEventRaised;
    public string lastSender;
    //接受广播事件
    public virtual void RaiseEvent(T value,object sender)
    {
        OnEventRaised?.Invoke(value);
        lastSender=sender.ToString();
    }
}
