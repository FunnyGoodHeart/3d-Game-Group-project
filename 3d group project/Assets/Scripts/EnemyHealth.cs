using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int EnemyHP = 10;
    [SerializeField] GameObject Player;
    PlayerAttack PlAtk;
    void Start()
    {
        PlAtk = Player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if(EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
            EnemyHP -= PlAtk.playerATK;
        }
    }
}
