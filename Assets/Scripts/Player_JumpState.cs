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

        rb.AddForce(Vector2.up * player.jumpForce * rb.mass, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.jumpMoveSpeed, rb.velocity.y);
    }
}
