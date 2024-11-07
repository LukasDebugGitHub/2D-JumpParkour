using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpState : Player_State
{
    public Player_JumpState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce * rb.gravityScale);
        
        if (player.IsWallDetected() && player.IsGroundDetected())
            stateTimer = player.jumpCornerTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.jumpMoveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(player.jumpKey))
            stateMachine.ChangeState(player.doubleJumpState);

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);

        if (player.IsWallDetected() && !player.IsGroundDetected() && stateTimer < 0)
            stateMachine.ChangeState(player.wallSlideState);
    }
}
