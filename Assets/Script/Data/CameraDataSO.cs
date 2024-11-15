using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Camera Data", menuName = "Data/Camera Data")]
public class CameraDataSO : ScriptableObject
{
    public float cameraSpeed;
    public float cameraScale;
    // public Transform player; // 玩家对象
    public Vector2 minBounds; // 地图最小边界
    public Vector2 maxBounds=new Vector2(1920,1080); // 地图最大边界
    public float smoothSpeed = 0.9f; // 平滑跟随速度
    public Vector3 offset; // 摄像机偏移
}
