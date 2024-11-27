using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectSlideTransition : MonoBehaviour
{
    public Transform slidingObject; // 滑动对象
    public Vector3 startPosition;   // 初始位置
    public Vector3 endPosition;     // 结束位置
    public float slideDuration = 1f; // 滑动时间

    private void Awake()
    {
        slidingObject = transform;
    }

    [ContextMenu("SlideIn")]
    public void SlideIn()
    {
        transform.DOMove(endPosition, slideDuration);
    }
    public void SlideOut()
    {
        transform.DOMove(startPosition, slideDuration);
    }
}