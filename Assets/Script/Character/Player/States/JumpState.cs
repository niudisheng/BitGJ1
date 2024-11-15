using UnityEngine.Events;

public class JumpState : PlayerState
{
    public JumpState(Player _player,PlayerStateMachine _stateMachine, States _state=States.jump) : base(_player,_stateMachine, _state)
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