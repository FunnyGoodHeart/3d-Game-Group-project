using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP = 10;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject healItem;
    [SerializeField] GameObject bulletItem;
    public bool enemyGotHit = false; //if enemy gets hit by bullet & out of chase range
    Slider enemySlider;
    PlayerAttack PlAtk;
    int maxEnemyHP;
    int chanceForHeal;
    int chanceForAmmo;
    int bowAtk;

    HardModeSkull hardMode;
    bool hardModeStarted = false;
    void Start()
    {
        PlAtk = Player.GetComponent<PlayerAttack>();
        enemySlider = GetComponentInChildren<Slider>();
        enemySlider.maxValue = enemyHP;
        enemySlider.value = enemyHP;
        GetComponentInChildren<Canvas>().enabled = false;
        chanceForHeal = Random.Range(1, 6);
        chanceForAmmo = Random.Range(1, 6);
        maxEnemyHP = enemyHP;

        GameObject Skull = GameObject.Find("TheHardModeSkull");
        hardMode = Skull.GetComponent<HardModeSkull>();
    }

    void Update()
    {
        if (hardMode.startTheFire == true && hardModeStarted == false)
        {
            enemyHP = maxEnemyHP;
            enemyHP *= hardMode.timesDiffuculty;
            enemySlider.maxValue = enemyHP;
            enemySlider.value = enemyHP;
            
        }
        if (enemyHP <= 0)
        {
            if(chanceForHeal == 1)
            {
                GameObject item = Instantiate(healItem, transform.position, Quaternion.identity);
            }
            if(chanceForAmmo == 1)
            {
                GameObject item = Instantiate(bulletItem, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
            if (enemyHP == enemySlider.maxValue)
            {
                GetComponentInChildren<Canvas>().enabled = true;
            }
            enemyHP -= PlAtk.playerSwordATK;
            enemySlider.value = enemyHP;
        }
        if (collision.gameObject.tag == "PlayerBullet")
        {
            if (enemyHP == enemySlider.maxValue)
            {
                GetComponentInChildren<Canvas>().enabled = true;
            }
            enemyHP -= PlAtk.playerBowATK;
            enemySlider.value = enemyHP;
            enemyGotHit = true;
            Destroy(collision.gameObject);
        }
    }
}
