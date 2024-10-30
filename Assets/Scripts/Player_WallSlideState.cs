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

        player.ZeroVelocity();  // Change it to SetVelocity to handle the slide speed

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
