using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GroundState : Player_State
{
    public Player_GroundState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.DoubleJumpReset();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(player.jumpKey) && player.IsGroundDetected())
            stateMachine.ChangeState(player.jumpState);
    }
}
