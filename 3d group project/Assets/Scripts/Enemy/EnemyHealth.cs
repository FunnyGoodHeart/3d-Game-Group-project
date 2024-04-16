using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHP = 10;
    [SerializeField] GameObject Player;
    public bool enemyGotHit = false; //if enemy gets hit by bullet & out of chase range
    Slider enemySlider;
    PlayerAttack PlAtk;
    void Start()
    {
        PlAtk = Player.GetComponent<PlayerAttack>();
        enemySlider = GetComponentInChildren<Slider>();
        enemySlider.maxValue = enemyHP;
        enemySlider.value = enemyHP;
        GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {
        if(enemyHP <= 0)
        {
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
