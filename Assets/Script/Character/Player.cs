using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : CharacterBase
{
    public Play2DInput playertest;
    public float forceMagnitude = 10f; // 调整这个值来改变力量大小
    public Vector2 direction= Vector2.zero;
    public Rigidbody2D rb;
    public Animator anim;
    
    private PlayerStateMachine stateMachine;
    
    private void Awake()
    {
        playertest = new Play2DInput();
        rb = this.transform.GetComponent<Rigidbody2D>();
         
        PlayerState idleState = new PlayerState(this,"Idle");
        stateMachine = new PlayerStateMachine();
        stateMachine.Initialize(idleState);
    }

    private void OnEnable()
    {
        playertest.Enable();
    }
    private void OnDisable()
    {
        playertest.Disable();
    }

    private void Update()
    {
        //获取输入
        direction = playertest.Player.Move.ReadValue<Vector2>();
        
        MoveDirection(direction);
        if (Input.GetKey(KeyCode.Space))
        {
            Shot();
        }
        
        
        
    }

    public void MoveDirection(Vector2 direction1)
    {
        //跳跃逻辑
        if (direction1.y > 0)
        {
            rb.AddForce(new Vector2(0, forceMagnitude));
        }
        
        rb.velocity = new Vector2(direction1.x* speed, rb.velocity.y);
    }

    public void Shot()
    {
        Debug.Log("shot");
    }
    
    /*
    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("碰撞");
        
        if (rb != null&&collision != null)
        {
            // 计算碰撞方向
            Vector3 direction2 = (transform.position - collision.transform.position).normalized;
            
            // 添加力，使其沿抛物线运动
            Vector3 force = direction2 * forceMagnitude + Vector3.up * forceMagnitude;
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
    */
}
