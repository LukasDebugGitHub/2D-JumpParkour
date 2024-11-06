using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WallSlideState : Player_State
{
    public Player_WallSlideState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // doing wall jump
        if (Input.GetKeyDown(player.jumpKey))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        // player goes of the wall
        if (xInput != 0 && xInput != player.facingDir)
            stateMachine.ChangeState(player.idleState);

        // over the negative y input, move faster down
        if (yInput < 0)
            rb.velocity = new Vector2(0, -player.wallSlideDownSpeed);
        else
            rb.velocity = new Vector2(0, -player.wallSlideSpeed);

        // goes to idle, when the player hits the ground
        if (player.IsGroundDetected() || !player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
