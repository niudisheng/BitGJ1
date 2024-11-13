using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    public States stateName;
    protected Player player; 
    public string animatorName;
 
    public PlayerState(Player _player,PlayerStateMachine _stateMachine, States _state) //   构造函数，将上述变量传入
    {
        player = _player; //获取player，也可以调用player中的参数    
        // this.stateMachine = _stateMachine;
        stateName = _state;
        stateMachine = _stateMachine;
        animatorName = stateName.ToString(); //将状态名转换为字符串，作为动画参数
    }
    
    public virtual void Enter()
    {
        
        player.anim.SetBool(animatorName,true);
        Debug.Log("Entering state: " + stateName);
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