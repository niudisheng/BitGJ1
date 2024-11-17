using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 bottomOffSet1;
    public Vector2 bottomOffSet2;
    public float checkRaduis1;
    public float checkRaduis2;
    public LayerMask GroundLayer;
    public LayerMask WallLayer;
    public bool isWall;
    public bool isGround;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (rb != null && collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = true;
    //    }
    //    if (rb != null && collision.gameObject.CompareTag("Wall"))
    //    {
    //        isWall = true;
    //    }
    //}
    private void Update()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position+bottomOffSet1, checkRaduis1, GroundLayer);
        isWall = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffSet2, checkRaduis2, WallLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position+bottomOffSet1,checkRaduis1);
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffSet2, checkRaduis2);
    }
}
