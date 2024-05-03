using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour
{
    GameObject player;
    public int enemyAmmoDamage = 1;

    HardModeSkull hardMode;
    bool hardModeStarted = false;
    private void Start()
    {
        player = GameObject.Find("Player");
        GameObject Skull = GameObject.Find("TheHardModeSkull");
        hardMode = Skull.GetComponent<HardModeSkull>();
    }
    private void Update()
    {
        if (hardMode.startTheFire == true && hardModeStarted == false)
        {
            enemyAmmoDamage *= hardMode.timesDiffuculty;
            hardModeStarted = true;
        }
            transform.LookAt(player.transform.position);
    }
}
