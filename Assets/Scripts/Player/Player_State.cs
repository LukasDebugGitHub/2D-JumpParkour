using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player_State
{
    protected Player_StateMachine stateMachine;
    protected Player player;

    private string animBoolName;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;

    public Player_State(Player _player, Player_StateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);

        rb = player.rb;
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        ChangeFromAnyState();
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }


    private void ChangeFromAnyState()
    {
        ChangeToAirState();
        ChangeToWallSlideState();
    }

    private void ChangeToAirState()
    {
        if (rb.velocity.y < 0 && !player.IsGroundDetected() && !player.IsWallDetected())
            stateMachine.ChangeState(player.airState);
    }
    private void ChangeToWallSlideState()
    {
        if (player.IsWallDetected() && !player.IsGroundDetected())
            stateMachine.ChangeState(player.wallSlideState);
    }
}
