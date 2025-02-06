using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPlayer : CharacterBase
{
    public static NewPlayer instance;
    public float speed = 5f;
    [Header("移动相关")]
    public bool isClick = false;
    public double clickTime =0;
    public Rigidbody2D rb;
    private void Start()
    {
        instance = this;
        stateMachine = new PlayerStateMachine();
        stateMachine.Initialize(this,new IdleState(this,stateMachine));
        rb = this.transform.GetComponent<Rigidbody2D>();
    }

    private Vector2 checkInput()
    {
        bool isMousePressed = Input.GetMouseButtonDown(0);
        if (isMousePressed)
        {
             Vector2 direction = Input.mousePosition.x>transform.position.x?new Vector2(1,0):new Vector2(-1,0);
             return direction;
        }
        return Vector2.zero;
    }
    private void move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = 0;
            isClick = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("move",false);
            anim.SetBool("idle", true);
            rb.velocity = Vector2.zero;
            isClick = false;
        }
        if (isClick)
        {
            clickTime += Time.deltaTime;
            if (clickTime >= 0.15)
            {
                if( Camera.main.ScreenToWorldPoint(Input.mousePosition).x -transform.position.x > 0.1)
                {
                    anim.SetBool("idle",false );
                    anim.SetBool("move",true);
                    direction = Vector2.right;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x < -0.1)
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("move", true);
                    direction = Vector2.left;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else 
                {
                    anim.SetBool("move", false);
                    anim.SetBool("idle", true);
                    direction = Vector2.zero;
                }
                rb.velocity = direction * speed;
            }
        }
    }
    private void Update()
    {
        
        if (Camera.main != null)
        {
            var input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(input);
        } 
          move();
    }

    private void FixedUpdate()
    {
        
    }
}
