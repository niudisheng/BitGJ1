public class JumpState : PlayerState
{
    public JumpState(Player _player, string stateName="Jumping") : base(_player, stateName)
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