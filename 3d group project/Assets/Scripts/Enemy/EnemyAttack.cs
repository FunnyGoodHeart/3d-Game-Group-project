using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Kind")]
    [SerializeField] bool physicalAttack;
    [SerializeField] bool rangedAttack;

    [Header("Atk")]
    public int enemyATK = 2;
    public int enemy2ndATK = 1; //if the enemy has 2 different ways to get hit

    [Header("Colliders")]
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject detectSphere;

    SphereCollider hitRange;
    private void Start()
    {
        hitRange = sphere.GetComponent<SphereCollider>();
        hitRange.enabled = false;
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
