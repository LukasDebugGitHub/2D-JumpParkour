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

        if (yInput < 0)
            player.SetVelocity(0, yInput * player.slideMoveSpeed);
        else if (yInput >= 0)
            player.SetVelocity(0, -player.slideSpeed);


        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(player.wallJumpState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
