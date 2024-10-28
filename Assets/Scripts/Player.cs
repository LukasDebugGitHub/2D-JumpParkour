using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim {  get; private set; }
    public Rigidbody2D rb { get; private set; }


    public Player_StateMachine stateMachine {  get; private set; }

    public Player_IdleState idleState { get; private set; }

    private void Awake()
    {
        stateMachine = new Player_StateMachine();

        idleState = new Player_IdleState(this, stateMachine, "Idle");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        stateMachine.Initialize(idleState);

    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

}
