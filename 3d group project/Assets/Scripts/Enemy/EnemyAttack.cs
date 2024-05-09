using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //for the parent of the enemy
    [Header("Attack Kind")]
    public bool physicalAttack;
    public bool rangedAttack;

    [Header("Atk")]
    public int enemyPhysicalATK = 2; //check bullet for to change dmg

    [Header("Cool Down")]
    public float emyPhyAtkCD = 5f;

    [Header("AmmoStuff")]
    [SerializeField] GameObject player;
    [SerializeField] float timeToFire = 1;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletLifetime = 2;
    float timer = 0;
    Animator ani;
    [SerializeField] float shootDistance = 7;
    void Update()
    {
        if(rangedAttack == true)
        {
            timer += Time.deltaTime;
            Vector3 playerPosition = player.transform.position;
            Vector3 shootDirection = playerPosition - transform.position;
            if (shootDirection.magnitude < shootDistance && timer >= timeToFire)
            {
                timer = 0;
                shootDirection.Normalize();
                GameObject enemyBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                enemyBullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
                Destroy(enemyBullet, bulletLifetime);
            }
        }
    }
}
