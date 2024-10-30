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

        rb.AddForce(Vector2.up * player.doubleJumpForce * rb.mass, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
