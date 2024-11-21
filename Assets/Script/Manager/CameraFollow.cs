using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CameraDataSO cameraData;

    private float cameraHalfWidth;
    private float cameraHalfHeight;
    
    float cameraSpeed;
    float cameraScale;
    public Transform player; // 玩家对象
    Vector2 minBounds; // 地图最小边界
    Vector2 maxBounds=new Vector2(1920,1080); // 地图最大边界
    float smoothSpeed = 0.9f; // 平滑跟随速度
    Vector3 offset; // 摄像机偏移
    void Awake()
    {
        
        offset = cameraData.offset;
        smoothSpeed = cameraData.smoothSpeed;        
        minBounds = cameraData.minBounds;
        maxBounds = cameraData.maxBounds;
    }
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        cameraHalfHeight = camera.orthographicSize;
        cameraHalfWidth = camera.aspect * cameraHalfHeight;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        // Debug.LogWarning(desiredPosition);
        var Diff = (transform.position-desiredPosition).magnitude;
        //Diff=0时要保持跟随，Speed要为1
        if (Diff < 0.1f)
        {
            cameraSpeed = 1;
        }
        else
        {
            //这里需要根据距离差值来设置cameraSpeed
            cameraSpeed = 1-Diff*0.01f;
        }
        //Debug.LogWarning(cameraSpeed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);
        
        this.transform.position = new Vector3(smoothedPosition.x,smoothedPosition.y, transform.position.z);
    }
}