using UnityEngine;

[ExecuteInEditMode]
public class EdgeDetectionEffect : MonoBehaviour
{
    public Material edgeDetectionMaterial; // 绑定边缘检测材质

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (edgeDetectionMaterial != null)
        {
            // 使用材质处理图像
            Graphics.Blit(src, dest, edgeDetectionMaterial);
        }
        else
        {
            // 如果没有材质，直接输出原图像
            Graphics.Blit(src, dest);
        }
    }
}