using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveState : PlayerState
{
    public MoveState(CharacterBase _player, PlayerStateMachine _stateMachine, States _state=States.move) : base(_player,_stateMachine, _state)
    {
        
    }
 
    public override void Enter()
    {
        base.Enter();
        
        
    }
 
    public override void Exit()
    {
        base.Exit();
    }
 
    public override void Update() //持续调用
    {
        base.Update();
        
    }
}