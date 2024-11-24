using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    public States stateName;
    protected CharacterBase player; 
    public string animatorName;
 
    public PlayerState(CharacterBase _player,PlayerStateMachine _stateMachine, States _state) //   构造函数，将上述变量传入
    {
        player = _player; //获取player，也可以调用player中的参数    
        stateName = _state;
        stateMachine = _stateMachine;
        animatorName = stateName.ToString(); //将状态名转换为字符串，作为动画参数
    }
    
    public virtual void Enter()
    {
        player.anim.SetBool(animatorName,true);
        //Debug.Log("Entering state: " + stateName);
        if (stateName != States.idle)
        {
            // Debug.LogWarning("Removing idle state");
            stateMachine.RemoveState(States.idle);
        }
    }
 
    public virtual void Update()
    {
        //在这里写状态的更新逻辑
    }
 
    public virtual void Exit()
    {
        //Debug.Log("Exiting state: " + animatorName);
        player.anim.SetBool(animatorName,false);
    }
 
}