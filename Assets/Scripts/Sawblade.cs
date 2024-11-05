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

    [Header("Chain")]
    [SerializeField] private GameObject prefabChain;
    [SerializeField] private int chainLength;
    [SerializeField] private float chainDistance;

    int chainValue;
    Vector2 newChainPosition = new Vector2(0, 5);
    
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

    private void Start()
    {
        newChainPosition = transform.position;
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

        CreateChain();
        
    }

    private void CreateChain()
    {
        if (chainLength > chainValue)
        {
            Instantiate(prefabChain, newChainPosition, transform.rotation);
            newChainPosition.y += chainDistance;
            chainValue++;
        }
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
