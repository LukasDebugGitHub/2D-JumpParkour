using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Info")]
    public float runSpeed;
    public float jumpForce;
    public float jumpMoveSpeed;
    public float fallMoveSpeed;
    public float doubleJumpForce;

    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private Transform wallCheck;

    private float facingDir = 1;
    private bool facingRight;


    #region Components
    public Rigidbody2D rb { get; private set; }
    public Animator anim {  get; private set; }
    #endregion

    #region States
    public Player_StateMachine stateMachine {  get; private set; }

    public Player_IdleState idleState { get; private set; }
    public Player_RunState runState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_AirState airState { get; private set; }
    public Player_DoubleJumpState doubleJumpState { get; private set; }
    public Player_WallSlideState wallSlideState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new Player_StateMachine();

        idleState = new Player_IdleState(this, stateMachine, "Idle");
        runState = new Player_RunState(this, stateMachine, "Run");
        jumpState = new Player_JumpState(this, stateMachine, "Jump");
        airState = new Player_AirState(this, stateMachine, "Air");
        doubleJumpState = new Player_DoubleJumpState(this, stateMachine, "DoubleJump");
        wallSlideState = new Player_WallSlideState(this, stateMachine, "WallSlide");

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
    }

    

    #region Velocity
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);

        FlipController(_xVelocity);
    }

    public void ZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }
    #endregion

    #region Flip
    private void Flip()
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

    #region Collision
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }
    #endregion
}
