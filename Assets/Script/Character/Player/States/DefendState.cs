using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class DefendState : PlayerState
{
    public DefendState(Player _player, PlayerStateMachine _stateMachine, States _state = States.defend) : base(_player, _stateMachine, _state)
    {

    }

    public override void Enter()
    {
        base.Enter();
        
        defending();
        Debug.Log("fine");
    }

    private void defending()
    {
        // player.rb.velocity = new Vector2(player.rb.velocity.x, 0);
        //DelayedAction.instance.StartDelayedAction(0.5f, defendcheck);
    }

    private void defendcheck()
    {
        //解除格挡
        stateMachine.RemoveState(States.rolling);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update() //持续调用
    {
        defending();

    }
}
