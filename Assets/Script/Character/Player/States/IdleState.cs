using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class IdleState : PlayerState
{
    public IdleState(CharacterBase _player, PlayerStateMachine _stateMachine, States _state=States.idle) : base(_player,_stateMachine, _state)
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