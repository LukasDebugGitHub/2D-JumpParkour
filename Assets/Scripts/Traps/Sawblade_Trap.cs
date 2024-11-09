using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sawblade_Trap : Trap
{
    [Header("Sawblade Info")]
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Vector2 endPos;
    [SerializeField] private float speed;
    [SerializeField] private bool startRightDir;
    [SerializeField] private bool startUpDir;

    private bool isRight;
    private bool isUp;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        isRight = startRightDir;
        isUp = startUpDir;
    }

    protected override void Update()
    {
        base.Update();

        anim.SetBool("On", isTrapOn);

        if (isTrapOn)
        {
            SawHorizontalMovement();
            SawVerticalMovement();
        }else
            rb.velocity = Vector2.zero;

    }

    private void SawHorizontalMovement()
    {
        if (startPos.x >= endPos.x)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (transform.position.x <= startPos.x)
        {
            isRight = true;
        }
        else if (transform.position.x >= endPos.x)
        {
            isRight = false;
        }

        if (isRight)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else if (!isRight)
            rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void SawVerticalMovement()
    {
        if (startPos.y >= endPos.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            return;
        }


        if (transform.position.y <= startPos.y)
        {
            isUp = true;
        }
        else if (transform.position.y >= endPos.y)
        {
            isUp = false;
        }

        if (isUp)
            rb.velocity = new Vector2(rb.velocity.x, speed);
        else if (!isUp)
            rb.velocity = new Vector2(rb.velocity.x, -speed);
    }
}
