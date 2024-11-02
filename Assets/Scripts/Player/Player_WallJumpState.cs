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

        player.FlipController(-player.facingDir);
        rb.AddForce(new Vector2(player.wallJumpXAxis * player.facingDir * rb.mass, player.wallJumpYAxis * rb.mass), ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
            player.SetVelocity(xInput * player.jumpMoveSpeed, rb.velocity.y);
    }
}
