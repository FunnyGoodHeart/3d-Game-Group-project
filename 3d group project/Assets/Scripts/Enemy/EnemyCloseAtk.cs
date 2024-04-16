using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtk : MonoBehaviour
{
    //for the trigger bubble around the enemy tagged EnemyClostHit
    EnemyAttack emyATK;
    SphereCollider hitBox;
    public int atkHolding;
    public bool enemyAttacked = false;
    bool coolDownActive;
    float coolDownTimer;
    void Start()
    {
        emyATK = GetComponentInParent<EnemyAttack>();
        atkHolding = emyATK.enemyPhysicalATK;
        hitBox = GetComponent<SphereCollider>();
    }
    void Update()
    {
        coolDownTimer += Time.deltaTime;
        if (enemyAttacked == true && coolDownActive == false)
        {
            hitBox.enabled = false;
            coolDownTimer = 0;
            coolDownActive = true;
        }
        if(coolDownActive == true && coolDownTimer >= emyATK.emyPhyAtkCD)
        {
            hitBox.enabled = true;
            enemyAttacked = false;
            coolDownActive = false;
        }
    }
}
