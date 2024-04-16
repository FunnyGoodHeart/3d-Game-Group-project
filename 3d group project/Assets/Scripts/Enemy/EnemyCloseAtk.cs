using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAtk : MonoBehaviour
{
    EnemyAttack emyATK;
    public int atkHolding;
    void Start()
    {
        emyATK = GetComponentInParent<EnemyAttack>();
        atkHolding = emyATK.enemyPhysicalATK;
        Debug.Log(atkHolding);
    }
    void Update()
    {
        
    }
}
