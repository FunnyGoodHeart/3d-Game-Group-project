using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //for the parent of the enemy
    [Header("Attack Kind")]
    [SerializeField] bool physicalAttack;
    [SerializeField] bool rangedAttack;

    [Header("Atk")]
    public int enemyPhysicalATK = 2;
    public int enemyRangeATK = 1;

    [Header("Cool Down")]
    public float emyPhyAtkCD = 5f;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
