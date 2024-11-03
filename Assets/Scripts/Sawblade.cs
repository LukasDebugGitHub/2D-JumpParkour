using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : MonoBehaviour
{
    [Header("Sawblade Info")]
    [SerializeField] private bool isBladeOn;
    [SerializeField] private float throwDistanceXAxis;
    [SerializeField] private float throwDistanceYAxis;
    
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
            coll.isTrigger = false;
        else if (!isBladeOn)
            coll.isTrigger = true;


        if (player.transform.position.x < gameObject.transform.position.x)
            checkDir = -1;
        else if (player.transform.position.x >= gameObject.transform.position.x)
            checkDir = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && isBladeOn)
        {
            player.rb.AddForce(new Vector2(throwDistanceXAxis * checkDir, throwDistanceYAxis), ForceMode2D.Impulse);

            player.stateMachine.ChangeState(player.getHitState);
        }
    }

}
