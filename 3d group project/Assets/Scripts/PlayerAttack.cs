using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Numbers")]
    [SerializeField] public int playerATK = 10;
    [SerializeField] float swordCoolDown = 2f;
    [SerializeField] float atkTime = 0.5f;

    [Header("Game Objects")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject swordBox;
    [SerializeField] GameObject bow;

    //ect
    BoxCollider swordBoxColl;
    Transform swordTrans;
    MeshRenderer swordShow;
    MeshRenderer bowShow;
    //sword bools
    bool justAttacked = false;
    bool swordCoolDownActive = false;
    bool swordReset = false;
    bool activeSword = true;
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
        bowShow = bow.GetComponent<MeshRenderer>();
        bowShow.enabled = false;
    }

    void Update()
    {
        TimerCD += Time.deltaTime; //coolDown
        ResetTime += Time.deltaTime; 
        if(activeSword == true)
        {
            SwordUpdate();
        }
    }
    void OnSwordSwitch()
    {
        if (activeSword == false)
        {
            activeBow = false;
            activeSword = true;
            bowShow.enabled = false;
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
                sword.transform.Rotate(0, 0, -90); // rotates sword if player clicks
                sword.transform.position = new Vector3(swordTrans.position.x + 0, swordTrans.position.y - 1, swordTrans.position.z + 0);
                swordBoxColl.enabled = true;
                justAttacked = true;
                swordReset = true;
                ResetTime = 0;
            }
            else if (activeBow == true)
            {
                bowAttack = true;
            }
        }
    }
    void SwordUpdate()
    {
        if (justAttacked == true) //prevents player from attacking again right after
        {
            if (swordCoolDownActive == false)
            {
                Debug.Log("CD start");
                TimerCD = 0f;
                swordCoolDownActive = true;
            }
            else if (TimerCD >= swordCoolDown && swordCoolDownActive == true)
            {
                Debug.Log("cooldown end");
                swordCoolDownActive = false;
                justAttacked = false;
            }
        }
        if (swordReset == true && ResetTime >= atkTime)
        {
            swordTrans = sword.GetComponent<Transform>();
            Debug.Log("Reset");
            sword.transform.Rotate(0, 0, 90);
            sword.transform.position = new Vector3(swordTrans.position.x - 0, swordTrans.position.y + 1, swordTrans.position.z - 0);
            swordBoxColl.enabled = false;
            swordReset = false;
        }
    }
}
