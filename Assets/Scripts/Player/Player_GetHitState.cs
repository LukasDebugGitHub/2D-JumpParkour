using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GetHitState : Player_State
{
    public Player_GetHitState(Player _player, Player_StateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.coroutine = player.WaitForNextHit();
        player.StartCoroutine(player.coroutine);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
