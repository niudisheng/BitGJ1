using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedAction : MonoBehaviour
{
    public static DelayedAction instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance!= this)
        {
            Destroy(gameObject);
        }
    }
    public void StartDelayedAction(float delayTime, UnityAction action)
    {
        StartCoroutine(ExecuteAfterDelay(delayTime, action));
    }

    private IEnumerator ExecuteAfterDelay(float delayTime, UnityAction action)
    {
        yield return new WaitForSeconds(delayTime);
        action?.Invoke();
    }
}