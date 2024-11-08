using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 为泛型 BaseEventSO<T> 创建自定义编辑器
//自行挂载到想要编辑的泛型 BaseEventSO<T> 对象上
[CustomEditor(typeof(BaseEventSO<>))]
public class BaseEventSOEditor<T> : Editor
{
    // 引用 BaseEventSO<T> 对象
    private BaseEventSO<T> baseEventSO;

    // 编辑器启用时调用
    private void OnEnable()
    {
        // 如果引用为空，初始化它
        if (baseEventSO == null)
        { 
            baseEventSO = (BaseEventSO<T>)target;
        }
    }

    // 重写 Inspector GUI
    public override void OnInspectorGUI()
    {
        // 调用基类方法，绘制默认 Inspector
        base.OnInspectorGUI();
        
        // 显示订阅数量
        EditorGUILayout.LabelField("订阅数量为" + GetListeners().Count);

        // 显示每个监听器
        foreach (var listener in GetListeners())
        {
            EditorGUILayout.LabelField(listener.ToString());
        }
    }

    // 获取所有事件的监听器
    private List<MonoBehaviour> GetListeners()
    {
        // 创建监听器列表
        List<MonoBehaviour> listeners = new List<MonoBehaviour>();

        // 如果 baseEventSO 或事件为空，返回空列表
        if (baseEventSO == null || baseEventSO.OnEventRaised == null)
        {
            return listeners;
        }

        // 获取所有订阅者
        var subscribers = baseEventSO.OnEventRaised.GetInvocationList();

        // 遍历每个订阅者
        foreach (var subscriber in subscribers)
        {
            // 尝试将订阅者转换为 MonoBehaviour
            var obj = subscriber.Target as MonoBehaviour;

            // 如果转换成功且不在列表中，添加到列表
            if (!listeners.Contains(obj))
            {
                listeners.Add(obj);
            }
        }

        // 返回监听器列表
        return listeners;
    }
}