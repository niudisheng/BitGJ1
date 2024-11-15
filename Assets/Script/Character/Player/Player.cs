using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using DG.Tweening;
public class Player : CharacterBase
{
    public Play2DInput playertest;
    public Vector2 direction= Vector2.zero;
    public Rigidbody2D rb;
    public Animator anim;
    
    public PlayerStateMachine stateMachine;
    


    [Header("参数设置")]
    public float forceMagnitude = 10f; // 调整这个值来改变力量大小
    public float speed = 5f; // 调整这个值来改变速度大小
    public float height;
    public float rolltime = 0.5f; // 调整这个值来改变高度大小
    
    
    private void Awake()
    {
        playertest = new Play2DInput();
        stateMachine = new PlayerStateMachine();
        rb = this.transform.GetComponent<Rigidbody2D>();
         
        PlayerState idleState = new IdleState(this,stateMachine);
        // stateMachine = new PlayerStateMachine();
        stateMachine.Initialize(this,idleState);
    }

    private void OnEnable()
    {
        playertest.Enable();
        // playertest.Player.Move.started += ctx => MoveDirection(ctx.ReadValue<Vector2>());
        //TODO: 绑定输入事件,非常重要
        playertest.Player.Jump.started += ctx => Jump();
        playertest.Player.Roll.started += ctx => roll();
        
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
        
    }

    public void MoveDirection(Vector2 direction1)
    {
        if (direction1 == Vector2.zero)
        {
            stateMachine.RemoveState(States.move);
            return;
        }
        stateMachine.AddState(new MoveState(this,stateMachine));
        rb.velocity = new Vector2(direction1.x* speed, rb.velocity.y);
    }

    public void Jump()
    {
        Debug.Log("jump");
        rb.velocity = new Vector2(rb.velocity.x, speed );
        stateMachine.AddState(new JumpState(this,stateMachine));
            
        
    }

    /// <summary>
    /// 碰撞地面检测
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb != null&&collision.gameObject.CompareTag("Ground"))
        {
            /*
            // 计算碰撞方向
            Vector3 direction2 = (transform.position - collision.transform.position).normalized;
            
            // 添加力，使其沿抛物线运动
            Vector3 force = direction2 * forceMagnitude + Vector3.up * forceMagnitude;
            rb.AddForce(force, ForceMode2D.Impulse);
            */
            stateMachine.RemoveState(States.jump);
        }
    }
    void roll()
    {
        stateMachine.AddState(new RollingState(this,stateMachine));
    }

}
