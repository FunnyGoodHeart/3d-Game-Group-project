using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtk : MonoBehaviour
{
    //for the trigger bubble around the enemy tagged EnemyClostHit
    EnemyAttack emyATK;
    Animator ani;
    SphereCollider hitBox;
    public int atkHolding;
    public bool enemyAttacked = false;
    public bool IsAttacking = false;
    bool coolDownActive;
    float coolDownTimer;
    void Start()
    {
        ani = GetComponentInParent<Animator>();
        emyATK = GetComponentInParent<EnemyAttack>();
        atkHolding = emyATK.enemyPhysicalATK;
        hitBox = GetComponent<SphereCollider>();
    }
    void Update()
    {
        coolDownTimer += Time.deltaTime;
        if (enemyAttacked == true && coolDownActive == false)
        {
            ani.SetBool("IsAttacking", true);
            IsAttacking = true;
            hitBox.enabled = false;
            coolDownTimer = 0;
            coolDownActive = true;
        }
        if(coolDownActive == true && coolDownTimer >= emyATK.emyPhyAtkCD)
        {
            ani.SetBool("IsAttacking", false);
            IsAttacking = false;
            hitBox.enabled = true;
            enemyAttacked = false;
            coolDownActive = false;
        }
    }
}
