using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_RunState : Player_GroundState
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

        player.SetVelocity(xInput * player.runSpeed * rb.gravityScale, rb.velocity.y);

        if (stateTimer < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, player.runBumping * rb.gravityScale);
            stateTimer = player.runBumpingTime;
        }

        if (xInput == 0 || player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }

}
