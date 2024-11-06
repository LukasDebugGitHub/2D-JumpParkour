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

        //player.ZeroVelocity();

    }
    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.runSpeed, rb.velocity.y);

        //if (player.timeValue < 0)
        //{
        //    player.timeValue = player.runBumpingTime;
        //    rb.AddForce(new Vector2(0, player.runBumping), ForceMode2D.Impulse);
        //}


        if (xInput == 0 || player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }

}
