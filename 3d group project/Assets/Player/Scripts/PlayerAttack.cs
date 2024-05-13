using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [Header("Numbers")]
    public int playerSwordATK = 10;
    public int playerBowATK = 5;
    [SerializeField] float swordCD = 2f;
    [SerializeField] float bowCD = 1f;
    [SerializeField] float atkTime = 0.5f;

    [Header("Game Objects")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject swordBox;
    [SerializeField] GameObject bow;
    [SerializeField] GameObject bowModle;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject swordTransform;
    [SerializeField] TextMeshProUGUI interact;
    [SerializeField] Canvas saveOrLoad;
    //ect
    PlayerBowShoot plBowShoots;
    BoxCollider swordBoxColl;
    Transform swordTrans;
    Transform swordPlacement;
    MeshRenderer swordShow;
    MeshRenderer bowShow;
    MeshRenderer arrowShow;
    AmmoBoxInteractable bulletbox;
    HardModeSkull theHARDMODE;
    PinappleInteracr PineInter;
    float coolDown = 2f;
    //sword bools
    bool justAttacked = false;
    bool CoolDownActive = false;
    bool swordReset = false;
    bool activeSword = true;
    bool nearBulletBox = false;
    bool nearTHESKULL = false;
    bool nearPineapple = false;
    bool nearCampfire = false;
    //Bow bools
    bool activeBow = false;
    public bool bowAttack = false;
    //timers
    float TimerCD;
    float ResetTime;
    void Start()
    {
        swordBoxColl = swordBox.GetComponent<BoxCollider>();
        swordBoxColl.enabled = false;
        swordShow = sword.GetComponent<MeshRenderer>();
        swordPlacement = swordTransform.GetComponent<Transform>();
        bowShow = bowModle.GetComponent<MeshRenderer>();
        arrowShow = arrow.GetComponent<MeshRenderer>();
        plBowShoots = bow.GetComponent<PlayerBowShoot>();
        bowShow.enabled = false;
        arrowShow.enabled = false;
        interact.enabled = false;
    }

    void Update()
    {
        swordPlacement = swordTransform.GetComponent<Transform>();
        TimerCD += Time.deltaTime; //coolDown
        ResetTime += Time.deltaTime; 
        if(activeSword == true)
        {
            SwordUpdate();
        }
        if (justAttacked == true) //prevents player from attacking again right after
        {
            if (CoolDownActive == false)
            {
                Debug.Log("CD start");
                TimerCD = 0f;
                CoolDownActive = true;
            }
            else if (TimerCD >= coolDown && CoolDownActive == true)
            {
                Debug.Log("cooldown end");
                if(activeBow == true)
                {
                    arrowShow.enabled = true;
                }
                CoolDownActive = false;
                justAttacked = false;
            }
        }
    }
    void OnSwordSwitch()
    {
        if (activeSword == false)
        {
            activeBow = false;
            activeSword = true;
            bowShow.enabled = false;
            arrowShow.enabled = false;
            swordShow.enabled = true;
        }
    }
    void OnBowSwitch()
    {
        if(activeBow == false)
        {
            activeSword = false;
            activeBow = true;
            swordShow.enabled = false;
            bowShow.enabled = true;
            arrowShow.enabled = true;
        }
    }
    void OnAttack() 
    {
        if(justAttacked == false)
        {
            if (activeSword == true)
            {
                swordTrans = sword.GetComponent<Transform>();
                Debug.Log("Swoosh");
                sword.transform.Rotate(0, 0, 90); // rotates sword if player clicks
                sword.transform.position = new Vector3(swordTrans.position.x + 0, swordTrans.position.y -0.5f, swordTrans.position.z +0);
                swordBoxColl.enabled = true;
                justAttacked = true;
                swordReset = true;
                coolDown = swordCD;
                ResetTime = 0;
            }
            else if (activeBow == true)
            {
                Debug.Log("Pew");
                bowAttack = true;
                arrowShow.enabled = false;
                justAttacked = true;
                coolDown = bowCD;
            }
        }
    }
    void SwordUpdate()
    {
        if (swordReset == true && ResetTime >= atkTime)
        {
            swordTrans = sword.GetComponent<Transform>();
            Debug.Log("Reset");
            sword.transform.Rotate(0, 0, -90);
            sword.transform.position = new Vector3(swordPlacement.position.x, swordPlacement.position.y, swordPlacement.position.z);
            swordBoxColl.enabled = false;
            swordReset = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("inRange");
        if (other.gameObject.tag == "AmmoRegen" && plBowShoots.maxBulletCount > plBowShoots.bulletCount)
        {
            Debug.Log("ammo collection");
            int bulletAdd = Random.Range(plBowShoots.minBulletAdd, plBowShoots.maxBulletCount);
            plBowShoots.bulletCount += bulletAdd;
            if(plBowShoots.bulletCount > plBowShoots.maxBulletCount)
            {
                plBowShoots.bulletCount = plBowShoots.maxBulletCount;
            }
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "BulletBox")
        {
            GameObject bBox = other.gameObject;
            bulletbox = bBox.GetComponentInParent<AmmoBoxInteractable>();
            if(bulletbox.recharging == false)
            {
                interact.enabled = true;
                interact.text = "Press E To Arrow";
            }
            nearBulletBox = true;
        }
        if(other.gameObject.tag == "THESKULL")
        {
            GameObject skull = other.gameObject;
            theHARDMODE = skull.GetComponentInParent<HardModeSkull>();
            if(theHARDMODE.startTheFire == false)
            {
                interact.enabled = true;
                interact.text = "Press E To Hard Mode";
            }
            nearTHESKULL = true;
        }
        if(other.gameObject.tag == "PineappleHeal")
        {
            GameObject PineappleObj = other.gameObject;
            PineInter = PineappleObj.GetComponent<PinappleInteracr>();
            if (PineInter.pineRecharging == false)
            {
                interact.enabled = true;
                interact.text = "Press E To Pineapple";
            }
            nearPineapple = true;
        }
        if(other.gameObject.tag == "Campfire")
        {
            nearCampfire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "PineappleHeal")
        {
            nearPineapple = false;
            
            interact.enabled = false;
        }
        if(other.gameObject.tag == "BulletBox")
        {
            nearBulletBox = false;
            interact.enabled = false;
        }
        if(other.gameObject.tag == "THESKULL")
        {
            nearTHESKULL = false;
            interact.enabled = false;
        }
        if(other.gameObject.tag == "Campfire")
        {
            nearCampfire = false;
        }
    }
    void OnInteract()
    {
        if(nearBulletBox == true && bulletbox.recharging == false)
        {
            bulletbox.recharging = true;
            interact.enabled = false;
        }
        else if (nearTHESKULL && theHARDMODE.startTheFire == false)
        {
            theHARDMODE.startTheFire = true;
            interact.enabled = false;
        }
        else if (nearPineapple && PineInter.pineRecharging == false)
        {
            PineInter.pineRecharging = true;
            interact.enabled = false;
        }
        else if (nearCampfire)
        {
            saveOrLoad.enabled = true;
        }
    }
}
