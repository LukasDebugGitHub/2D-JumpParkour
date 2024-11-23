using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Trap Info")]
    [SerializeField] protected bool isTrapOn;
    [SerializeField] protected float playerForceX;
    [SerializeField] protected float playerForceY;
    [SerializeField] protected int damage;

    protected float checkDir;

    protected Player player;
    protected Animator anim;
    protected Collider2D coll;
    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        player = FindAnyObjectByType<Player>();
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (isTrapOn)
            coll.enabled = true;
        if (!isTrapOn)
            coll.enabled = false;


        if (player.transform.position.x < gameObject.transform.position.x)
            checkDir = -1;
        else if (player.transform.position.x >= gameObject.transform.position.x)
            checkDir = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isTrapOn)
        {
            player.rb.velocity = new Vector2(playerForceX * checkDir, playerForceY);

            player.DamageInput(damage);

            player.stateMachine.ChangeState(player.getHitState);
        }
    }
}
