using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Control1 : MonoBehaviour
{
    UnityAction onSkill1;
    public LineRenderer lineRenderer;
    public bool isSkill1Active;
    public List<Vector2> Points;
    public Rigidbody2D rb;
    public void SetOnSkill1()
    {
        //时空断裂
        GameManager.SetTimeScale(0.1f);
        isSkill1Active = true;
        DelayedAction.instance.StartDelayedAction(2f, () =>
        {
            GameManager.SetTimeScale(1f) ;
            isSkill1Active = false;
        });
    }
    
    public void OnPointerClick(Vector2 position)
    {
        if (isSkill1Active == false)
        {
            return;
        }
        
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, position);
        Points.Add(position);
        
    }

    private void Update()
    {
        if (!isSkill1Active)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            Vector2 mousePosition = Input.mousePosition;
            Camera mainCamera = Camera.main;
            Vector3 worldPosition =
                mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));
            OnPointerClick(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            crush();
        }
    }

    private void crush()
    {
        
        // 当鼠标松开时,计算曲线
        if (Points == null || Points.Count < 2)
        {
            Debug.LogWarning("Not enough points to analyze the curve.");
            return;
        }
        // 获取头和尾
        Vector2 head = Points[0];
        Vector2 tail = Points[Points.Count - 1];

        Vector2 overallTangent = Vector2.zero;
        // 计算切点

        for (int i = 0; i < Points.Count - 1; i++)
        {
            Vector2 tangent = Points[i + 1] - Points[i];
            overallTangent += tangent.normalized;
        }
        // 计算平均切线
        overallTangent /= (Points.Count - 1);
        overallTangent.Normalize();
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0, head);
        lineRenderer.SetPosition(1, overallTangent);
        lineRenderer.SetPosition(2, tail);

        Debug.Log($"Overall Tangent: {overallTangent}");
        float movetime = 0.2f;
        lineRenderer.enabled = false;
        // 移动逻辑
        rb.DOMove(head, movetime).OnComplete(
            () =>
            {
                rb.DOMove(overallTangent, movetime).OnComplete(
                    () =>rb.DOMove(tail, movetime));
            });
        lineRenderer.positionCount = 0;
    }
}
