using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StateMachine
{
    public Player_State currentState {  get; private set; }

    public void Initialize(Player_State _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(Player_State _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
