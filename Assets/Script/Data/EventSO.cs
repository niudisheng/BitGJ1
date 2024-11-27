using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="EventSO",menuName ="Event/EventSO")]
public class EventSO : MonoBehaviour
{
    public UnityAction UnityAction;
    public void OnEventRaised()
    {
        UnityAction();
    }
}
