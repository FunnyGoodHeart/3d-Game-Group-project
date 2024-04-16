using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHP = 50;
    [SerializeField] int healAmmount = 10;
    [SerializeField] GameObject stats;
    [SerializeField] bool testingHealth = false;
    int playerMaxHP;
    Slider healthBar;
    GameObject emyHitBox;
    EnemyCloseAtk emyATK;
    private void Start()
    {
        playerMaxHP = playerHP;
        healthBar = stats.GetComponentInChildren<Slider>();
        healthBar.maxValue = playerMaxHP;
        if (testingHealth == true)
        {
            playerHP -= 40;
        }
        healthBar.value = playerHP;
    }
    private void OnTriggerEnter(Collider collison)
    {
        if (collison.gameObject.tag == "EnemyClostHit")
        {
            emyHitBox = collison.gameObject; //collects info
            emyATK = emyHitBox.GetComponent<EnemyCloseAtk>();
            if (emyATK.enemyAttacked == false)
            {
                playerHP -= emyATK.atkHolding;
                healthBar.value = playerHP;
                emyATK.enemyAttacked = true; //if false then atk
                Debug.Log(playerHP);
            }
        }
        if(collison.gameObject.tag == "HealingItem" && playerHP <= playerMaxHP)
        {
            Debug.Log("healing");
            playerHP += healAmmount;
            if(playerHP >= playerMaxHP)
            {
                playerHP = playerMaxHP;
            }
            healthBar.value = playerHP;
            Destroy(collison.gameObject);
        }
    }
}
