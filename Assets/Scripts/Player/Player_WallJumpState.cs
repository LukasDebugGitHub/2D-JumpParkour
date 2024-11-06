using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WallJumpState : Player_State
{
    public Player_WallJumpState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.airMoveTime;

        player.SetVelocity(player.wallJumpForceX * rb.gravityScale * -player.facingDir, player.wallJumpForceY * rb.gravityScale);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(player.airState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
