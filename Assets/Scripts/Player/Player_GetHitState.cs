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

        player.coll.enabled = false;

        stateTimer = player.spawnTime;
    }

    public override void Exit()
    {
        base.Exit();

        player.coll.enabled = true;
    }

    public override void Update()
    {
        base.Update();
            
        player.transform.Rotate(Vector3.forward * Time.deltaTime * player.hitRotationSpeed);

        if (stateTimer < 0)
        {
            player.SpawnPlayer();
        }
    }
}
