using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackRange = 1f;
    private Rigidbody enemyRigidbody;
    public Movements playerscript;
    private Transform player;




    public float alertRange;
    public Animator enemyanimator;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyRigidbody = GetComponent<Rigidbody>();





    }

    private void Update()
    {




        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= alertRange)
        {
            Debug.Log("Scream");
            enemyanimator.SetTrigger("Turn");
            transform.LookAt(player.position);

            StartCoroutine(playerDetection());
        }



    }

    IEnumerator playerDetection()
    {
        yield return new WaitForSeconds(2);

        playerDectected();

    }

    public void playerDectected()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            enemyanimator.SetBool("isWalking", false);

            Attack();
        }
        else
        {
            enemyanimator.SetBool("isWalking", true);
            enemyanimator.SetBool("attack", false);
            // move the enemy towards the player's position
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


            transform.LookAt(player.position);
        }
    }


    public void HandHit()
    {
        playerscript.hitanim = true;
    }

    public void HandNotHit()
    {
        playerscript.hitanim = false;
    }

    private void Attack()
    {
        enemyanimator.SetBool("attack", true);
    }










}
