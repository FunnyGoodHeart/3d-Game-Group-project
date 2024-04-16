using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHP = 50;
    [SerializeField] GameObject stats;
    int playerMaxHP;
    Slider healthBar;
    GameObject emyHitBox;
    EnemyCloseAtk emyATK;
    private void Start()
    {
        playerMaxHP = playerHP;
        healthBar = stats.GetComponentInChildren<Slider>();
        healthBar.maxValue = playerMaxHP;
        healthBar.value = playerHP;
    }
    private void OnTriggerEnter(Collider collison)
    {
        if(collison.gameObject.tag == "EnemyClostHit")
        {
            emyHitBox = collison.gameObject;
            emyATK = emyHitBox.GetComponent<EnemyCloseAtk>();
            playerHP -= emyATK.atkHolding;
            healthBar.value = playerHP;
            Debug.Log(playerHP);
        }
    }
}
