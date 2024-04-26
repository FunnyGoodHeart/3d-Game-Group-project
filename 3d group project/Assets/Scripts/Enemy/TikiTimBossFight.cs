using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TikiTimBossFight : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int bossHealth = 100;
    [SerializeField] GameObject bossArea;
    [SerializeField] int chaseDistance = 5;
    bool gothit = false;
    bool startChasing = false;
    InBossArena BA;
    NavMeshAgent agent;
    Animator ani;
    float timer;
    void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        BA = bossArea.GetComponent<InBossArena>();
    }

    void Update()
    {
        Vector3 moveDir = player.transform.position - transform.position;
        if (gothit == true && startChasing == false) //starts chaisng player and start chase timer
        {
            startChasing = true;
        }
        if (moveDir.magnitude < chaseDistance || startChasing == true) // if the player is close
        {
            agent.destination = player.transform.position;
        }
    }
}
