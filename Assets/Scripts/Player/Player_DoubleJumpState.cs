using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DoubleJumpState : Player_State
{
    public Player_DoubleJumpState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(rb.velocity.x, player.doubleJumpForce * rb.gravityScale);

        player.doubleJumpCounter--;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.jumpMoveSpeed, rb.velocity.y);
        

        if (rb.velocity.y < 0)
            stateMachine.ChangeState(player.airState);
        
        if(player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlideState);


        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
