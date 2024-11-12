using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player; 
    public string animatorName;
 
    public PlayerState(Player _player, string _animBoolName) //   构造函数，将上述变量传入
    {
        this.player = _player; //获取player，也可以调用player中的参数    
        // this.stateMachine = _stateMachine;
        this.animatorName = _animBoolName; //动画参数的名字
    }
 
    public virtual void Enter()
    {
        Rigidbody2D rb = player.rb;
        player.anim.SetBool(animatorName,true);
    }
 
    public virtual void Update()
    {
        //在这里写状态的更新逻辑
    }
 
    public virtual void Exit()
    {
        player.anim.SetBool(animatorName,false); //退出当前状态时，将动画参数设置为false
    }
 
}