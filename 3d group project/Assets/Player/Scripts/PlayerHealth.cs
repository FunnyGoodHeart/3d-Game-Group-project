using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHP = 50;
    [SerializeField] int healAmmount = 10;
    [SerializeField] GameObject healthBarHold;
    [SerializeField] GameObject boss;
    [SerializeField] Canvas deathScreen;

    public int emeraldCount = 0;
    [SerializeField] int totalEmeraldsInGame = 4;
    [SerializeField] GameObject emeraldCounterGO;

    Slider healthBar;
    public int playerMaxHP;
    TikiTimBossFight tiki;
    GameObject emyHitBox;
    EnemyCloseAtk emyATK;
    EnemyAmmo emyAm;

    TextMeshProUGUI emeraldCountTxt;
    bool firstEmerald = true;
    private void Start()
    {
        emeraldCountTxt = emeraldCounterGO.GetComponent<TextMeshProUGUI>();
        tiki = boss.GetComponent<TikiTimBossFight>();
        playerMaxHP = playerHP;
        healthBar = healthBarHold.GetComponent<Slider>();
        healthBar.maxValue = playerMaxHP;
        healthBar.value = playerHP;
        deathScreen.enabled = false;
        emeraldCountTxt.enabled = false;
    }
    private void Update()
    {
        healthBar.value = playerHP;
        if (playerHP <= 0)
        {
            deathScreen.enabled = true;
        }
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
        if(collison.gameObject.tag == "enemyBullet")
        {
            GameObject emyAmHold = collison.gameObject;
            emyAm = emyAmHold.GetComponent<EnemyAmmo>();
            playerHP -= emyAm.enemyAmmoDamage;
            healthBar.value = playerHP;
            Destroy(collison.gameObject);
        }
        if(collison.gameObject.tag == "BossEnemyAttack")
        {
            Debug.Log("boss hit");
            playerHP -= tiki.bossDmg;
            healthBar.value = playerHP;
        }
        if(collison.gameObject.tag == "HealingItem" && playerHP < playerMaxHP)
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
        if(collison.gameObject.tag == "Emerald")
        {
            emeraldCount += 1;
            if (firstEmerald == true)
            {
                emeraldCountTxt.enabled = true;
            }
            emeraldCountTxt.text = "Emeralds Collected: " + emeraldCount + "/" + totalEmeraldsInGame;
            Destroy(collison.gameObject);
        }
    }
}
