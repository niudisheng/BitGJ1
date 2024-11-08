using UnityEngine;
using UnityEngine.Events;
// 泛型事件监听器类
public class BaseEventListener<T> : MonoBehaviour
{
    [Header("脚本化对象，负责触发事件")]
    public BaseEventSO<T> eventSO;
    [Header("发广播时执行的函数")]
    public UnityEvent<T> response;

    // 脚本启用时调用
    private void OnEnable()
    {
        // 如果事件对象不为空，订阅事件
        if (eventSO != null)
        {
            
            eventSO.OnEventRaised += OnEventRaised;
        } 
    }

    // 脚本禁用时调用
    private void OnDisable()
    {
        // 如果事件对象不为空，取消订阅事件
        if (eventSO != null)
        {
            eventSO.OnEventRaised -= OnEventRaised;
        }
    }

    // 当事件触发时调用的方法
    private void OnEventRaised(T value)
    {
        //respose里的方法都会被调用，并传入参数value
        response.Invoke(value);
    }
}