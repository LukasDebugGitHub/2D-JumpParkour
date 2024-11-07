using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AirState : Player_State
{
    public Player_AirState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (Input.GetKeyDown(player.jumpKey) && player.doubleJumpCounter > 0)
            stateMachine.ChangeState(player.doubleJumpState);

        if (player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlideState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);

        if (xInput != 0)
            player.SetVelocity(player.airMoveSpeed * xInput, rb.velocity.y);
    }
}
