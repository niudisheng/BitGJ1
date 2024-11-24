using UnityEngine;


public class RollingState : PlayerState
{
    public Rigidbody2D rb;
    public float rolltime = 0.5f;
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
        player = player as Player;
        
        var x_velocity = player.height / rolltime;
        // player.rb.velocity = new Vector2(x_velocity,player.rb.velocity.y);
        DelayedAction.instance.StartDelayedAction( 0.5f,rollcheck );

    }

    private void rollcheck()
    {
        //解除翻滚
        stateMachine.RemoveState(States.rolling);
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