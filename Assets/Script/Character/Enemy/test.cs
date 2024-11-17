using UnityEngine;

public class ParabolicMovement2D : MonoBehaviour
{
    public float forceMagnitude = 10f; // 调整这个值来改变力量大小

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            if (rb != null)
            {
                // 计算碰撞方向
                Vector2 direction = (transform.position - collision.transform.position).normalized;
            
                // 添加力，使其沿抛物线运动
                Vector2 force = direction * forceMagnitude + Vector2.up * forceMagnitude;
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
        
    }
}