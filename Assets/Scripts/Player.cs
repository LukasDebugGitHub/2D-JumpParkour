using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private float speed;

    public float horizontalInput;

    private float facingDir;
    private bool facingRight;


    #region Components
    public Rigidbody2D rb { get; private set; }
    public Animator anim {  get; private set; }
    #endregion

    #region States
    public Player_StateMachine stateMachine {  get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_RunState runState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new Player_StateMachine();

        idleState = new Player_IdleState(this, stateMachine, "Idle");
        runState = new Player_RunState(this, stateMachine, "Run");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        
        stateMachine.Initialize(idleState);

    }

    private void Update()
    {
        stateMachine.currentState.Update();

        horizontalInput = Input.GetAxisRaw("Horizontal");
    }


    public void SetVelocity()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        FlipController(horizontalInput);
    }

    public void ZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    #region Flip
    public void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    public void FlipController(float _x)
    {
        if (_x < 0 && !facingRight)
            Flip();
        else if (_x > 0 && facingRight)
            Flip();
    }
    #endregion
}
