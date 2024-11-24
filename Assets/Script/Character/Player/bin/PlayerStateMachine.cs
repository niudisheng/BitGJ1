using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlayerStateMachine
{
    public PlayerState currentState {get; private set;} //申明一个状态
    private List<PlayerState> states = new (); //申明一个状态列表
    private CharacterBase player;
    
    
    public void Initialize(CharacterBase _player,PlayerState _startState)
    {
        AddState(_startState);
        player = _player;
    }
    /*
    public void ChangeState(PlayerState _newState)
    {
        //currentState.Exit(); // 退出当前状态
        
        currentState = _newState;
        currentState.Enter();
    }
    */

    public void AddState(PlayerState _state)
    {
        states.Add(_state);
        _state.Enter();
    }
    public void RemoveState(States _state)
    {
        foreach (var state in states.ToList())
        {
            if (state.stateName == _state)
            {
                state.Exit();
                states.Remove(state);
            }
        }
        //检测是否没有状态
        if (states.Count == 0)
        {
            AddState(new IdleState(player,this));
        }
    }

    public bool CheckState(States _state)
    {
        foreach (var state in states)
        {
            if (state.stateName == _state)
            {
                return true;
            }
        }

        return false;
    }

}