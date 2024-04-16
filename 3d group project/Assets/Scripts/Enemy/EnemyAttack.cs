using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Kind")]
    [SerializeField] bool physicalAttack;
    [SerializeField] bool rangedAttack;

    [Header("Atk")]
    public int enemyPhysicalATK = 2;
    public int enemyRangeATK = 1; 

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
