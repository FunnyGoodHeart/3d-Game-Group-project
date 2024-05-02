using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxInteractable : MonoBehaviour
{
    public bool recharging;
    [SerializeField] int rechargeTime = 10;
    [SerializeField] int GiveArrowAmmount = 5;
    [Header("ArrowsInBox")]
    [SerializeField] GameObject arrow1;
    [SerializeField] GameObject arrow2;
    [SerializeField] GameObject arrow3;

    GameObject player;
    MeshRenderer arrowMesh1;
    MeshRenderer arrowMesh2;
    MeshRenderer arrowMesh3;
    PlayerBowShoot plBow;
    bool currentlyRecharging = false;
    float timer;
    void Start()
    {
        arrowMesh1 = arrow1.GetComponent<MeshRenderer>();
        arrowMesh2 = arrow2.GetComponent<MeshRenderer>();
        arrowMesh3 = arrow3.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (recharging == true && currentlyRecharging == false)
        {
            player = GameObject.Find("Player");
            plBow = player.GetComponentInChildren<PlayerBowShoot>();
            Debug.Log("Start Arrows");
            if(plBow.bulletCount < plBow.maxBulletCount)
            {
                currentlyRecharging = true;
                timer = 0;
                plBow.bulletCount += GiveArrowAmmount;
                if (plBow.maxBulletCount < plBow.bulletCount)
                {
                    plBow.bulletCount = plBow.maxBulletCount;
                }
                arrowMesh1.enabled = false;
                arrowMesh2.enabled = false;
                arrowMesh3.enabled = false;
            }
            if(plBow.bulletCount == plBow.maxBulletCount)
            {
                recharging = false;
            }
        }
        if(currentlyRecharging == true && timer >= rechargeTime)
        {
            currentlyRecharging = false;
            recharging = false;
            arrowMesh1.enabled = true;
            arrowMesh2.enabled = true;
            arrowMesh3.enabled = true;
        }
    }
}
