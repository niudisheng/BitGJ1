using UnityEngine;


public class RollingState : PlayerState
{
    
    public RollingState(Player _player, PlayerStateMachine _stateMachine,States _state=States.rolling) : base(_player,_stateMachine, _state)
    {
        
    }
 
    public override void Enter()
    {
        base.Enter();
        rolling();  
        
    }

    private void rolling()
    {
        var rolltime = player.rolltime;
        var x_velocity = player.height / rolltime;
        Debug.Log(x_velocity);
        player.rb.velocity = new Vector2(x_velocity,player.rb.velocity.y);
        DelayedAction.instance.StartDelayedAction( 0.5f,rollcheck );

    }

    private void rollcheck()
    {
        //解除翻滚
        if (player.stateMachine.currentState == this)
        {
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
        
        
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