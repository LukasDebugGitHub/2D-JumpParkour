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

    protected float stateTimer;

    protected int doubleJumpCounter;
    protected int doubleJumpCount;

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
        player.anim.SetFloat("yVelocity", rb.velocity.y);



        stateTimer -= Time.deltaTime;

    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
