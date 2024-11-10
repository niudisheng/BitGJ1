using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class IdleState : PlayerState
{
    public IdleState(Player _player, string stateName="Idle") : base(_player, stateName)
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