using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    [Header("Sawblade Info")]
    [SerializeField] private bool isBladeOn;
    [SerializeField] private float throwDistanceXAxis;
    [SerializeField] private float throwDistanceYAxis;
    [SerializeField] private int damage;

    private float checkDir;

    private Player player;
    private Animator anim;
    private Collider2D coll;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        anim = GetComponentInChildren<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        anim.SetBool("On", isBladeOn);

        if (isBladeOn)
            coll.enabled = true;
        if (!isBladeOn)
            coll.enabled = false;

        if (player.transform.position.x < gameObject.transform.position.x)
            checkDir = -1;
        else if (player.transform.position.x >= gameObject.transform.position.x)
            checkDir = 1;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject && isBladeOn && !player.isInvincible)
        {
            player.rb.AddForce(new Vector2(throwDistanceXAxis * checkDir, throwDistanceYAxis), ForceMode2D.Impulse);

            player.DamageOutput(damage);

            player.stateMachine.ChangeState(player.getHitState);
        }
    }
}
