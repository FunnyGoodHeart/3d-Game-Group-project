using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    [Header("moving or still")]
    [SerializeField] bool movingEnemy = true;
    [SerializeField] bool stillEnemy = false;

    [Header("Other Stuff")]
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance = 10;
    [SerializeField] int gotHitTimeRange = 5;
    bool startChasing = false;
    float gotHitTimer;
    Animator ani;
    EnemyHealth emyHealth;
    EnemyCloseAtk emyCA;
    EnemyAttack emyAtk;
    NavMeshAgent agent;
    Vector3 home;

    void Start()
    {
        ani = GetComponent<Animator>();
        emyCA = GetComponentInChildren<EnemyCloseAtk>();
        emyAtk = GetComponent<EnemyAttack>();
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
        emyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if(movingEnemy == true)
        {
            if(emyAtk.rangedAttack == true || emyAtk.physicalAttack == true && emyCA.IsAttacking == false)
            {
                gotHitTimer += Time.deltaTime;
                Vector3 moveDir = player.transform.position - transform.position;
                Vector3 closeHome = home - transform.position;
                if (emyHealth.enemyGotHit == true && startChasing == false) //starts chaisng player and start chase timer
                {
                    gotHitTimer = 0;
                    startChasing = true;
                }
                if (gotHitTimer >= gotHitTimeRange) //end out of chase range chase
                {
                    startChasing = false;
                    emyHealth.enemyGotHit = false;
                }
                if (moveDir.magnitude < chaseDistance || startChasing == true) // if the player is close
                {
                    agent.destination = player.transform.position;
                    ani.SetFloat("Speed", agent.destination.magnitude);
                }
                else if(closeHome.magnitude > 1)
                {
                    agent.destination = home;
                    //ani.SetFloat("Speed", agent.destination.magnitude);
                }
                else if(closeHome.magnitude < 1)//player too far away
                {
                    Debug.Log("must of been the wind");
                    ani.SetFloat("Speed", 0);
                }
            }
        }
        else if(stillEnemy == true)
        {
            
            transform.LookAt(player.transform.position);
        }
        
    }
}
