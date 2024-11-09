
using UnityEngine;
public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState {get; private set;} //申明一个状态
    
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState; //初始化状态
        currentState.Enter(); //进入状态
    }
 
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit(); // 退出当前状态
        currentState = _newState;
        currentState.Enter();
    }
}