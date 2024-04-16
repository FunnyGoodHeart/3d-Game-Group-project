using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Numbers")]
    [SerializeField] public int playerSwordATK = 10;
    [SerializeField] public int playerBowATK = 5;
    [SerializeField] float swordCD = 2f;
    [SerializeField] float bowCD = 1f;
    [SerializeField] float atkTime = 0.5f;

    [Header("Game Objects")]
    [SerializeField] GameObject sword;
    [SerializeField] GameObject swordBox;
    [SerializeField] GameObject bow;
    [SerializeField] GameObject swordTransform;
    //ect
    BoxCollider swordBoxColl;
    Transform swordTrans;
    Transform swordPlacement;
    MeshRenderer swordShow;
    MeshRenderer bowShow;
    float coolDown = 2f;
    //sword bools
    bool justAttacked = false;
    bool CoolDownActive = false;
    bool swordReset = false;
    bool bowReset = false;
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
        swordPlacement = swordTransform.GetComponent<Transform>();
        bowShow = bow.GetComponent<MeshRenderer>();
        bowShow.enabled = false;
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
            sword.transform.Rotate(0, 0, 90);
            sword.transform.position = new Vector3(swordPlacement.position.x, swordPlacement.position.y, swordPlacement.position.z);
            swordBoxColl.enabled = false;
            swordReset = false;
        }
    }
}
