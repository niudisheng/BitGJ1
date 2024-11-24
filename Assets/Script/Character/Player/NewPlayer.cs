using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewPlayer : CharacterBase
{
    
    public float speed = 5f;
    private Vector2 direction;
    private void Start()
    {
        
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
    public void MoveDirection(Vector2 direction1)
    {
        //基础移动
        if (direction1 == Vector2.zero)
        {
            stateMachine.RemoveState(States.move);
            return;
        }
        stateMachine.AddState(new MoveState(this,stateMachine));
        rb.velocity = new Vector2(direction1.x* speed, rb.velocity.y);
    }
    void Update()
    {
         direction=checkInput();
         MoveDirection(direction);


    }

    private void FixedUpdate()
    {
        
    }
}
