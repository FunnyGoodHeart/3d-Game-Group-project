using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinappleInteracr : MonoBehaviour
{
    public bool pineRecharging;
    [SerializeField] int healAmmount = 25;
    [SerializeField] int rechargedTime = 10;
    [SerializeField] GameObject pinappleBaseGO;
    [SerializeField] GameObject pinapppleLeafsGO;

    GameObject player;
    MeshRenderer pinappleBase;
    MeshRenderer pinappleLeafs;
    PlayerHealth PlHp;

    bool currentlyReCharging = false;
    float Timer;
    void Start()
    {
        pinappleBase = pinappleBaseGO.GetComponent<MeshRenderer>();
        pinappleLeafs = pinapppleLeafsGO.GetComponent<MeshRenderer>();
        player = GameObject.Find("Player");
        PlHp = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (pineRecharging == true && currentlyReCharging == false)
        {
            if(PlHp.playerMaxHP > PlHp.playerHP)
            {
                PlHp.playerHP += healAmmount;
                if(PlHp.playerHP > PlHp.playerMaxHP)
                {
                    PlHp.playerHP = PlHp.playerMaxHP;
                }
                pinappleBase.enabled = false;
                pinappleLeafs.enabled = false;
                Timer = 0;
                currentlyReCharging = true;
            }
        }
        if(currentlyReCharging && Timer >= rechargedTime)
        {
            pinappleBase.enabled = true;
            pinappleLeafs.enabled = true;
            pineRecharging = false;
            currentlyReCharging = false;
        }
    }
}
