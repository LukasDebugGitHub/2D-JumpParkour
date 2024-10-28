using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RunState : Player_State
{
    public Player_RunState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
    public override void Update()
    {
        base.Update();

        player.SetVelocity();

        if (rb.velocity == Vector2.zero)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
