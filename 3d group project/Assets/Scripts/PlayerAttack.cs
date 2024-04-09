using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Numbers")]
    [SerializeField] public int playerATK = 10;
    [SerializeField] float SwordCoolDown = 2f;
    [SerializeField] float AtkTime = 0.5f;

    [Header("Game Objects")]
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject SwordBox;

    //ect
    BoxCollider BoxColl;
    Transform swordTrans;
    bool justAttacked = false;
    bool SwordCoolDownActive = false;
    bool swordReset = false;
    bool activeSword = true;
    float SwordTimerCD;
    float SwordResetTime;
    void Start()
    {
        BoxColl = SwordBox.GetComponent<BoxCollider>();
        BoxColl.enabled = false;
    }

    void Update()
    {
        SwordTimerCD += Time.deltaTime; //coolDown
        SwordResetTime += Time.deltaTime;
        SwordUpdate();
    }
    void OnAttack() 
    {
        if(justAttacked == false)
        {
            if(activeSword == true)
            {
                swordTrans = Sword.GetComponent<Transform>();
                Debug.Log("Swoosh");
                Sword.transform.Rotate(0, 0, -90); // rotates sword if player clicks
                Sword.transform.position = new Vector3(swordTrans.position.x + 0, swordTrans.position.y - 1, swordTrans.position.z + 0);
                BoxColl.enabled = true;
                justAttacked = true;
                swordReset = true;
                SwordResetTime = 0;
            }
        }
    }
    void SwordUpdate()
    {
        if (justAttacked == true) //prevents player from attacking again right after
        {
            if (SwordCoolDownActive == false)
            {
                Debug.Log("CD start");
                SwordTimerCD = 0f;
                SwordCoolDownActive = true;
            }
            else if (SwordTimerCD >= SwordCoolDown && SwordCoolDownActive == true)
            {
                Debug.Log("cooldown end");
                SwordCoolDownActive = false;
                justAttacked = false;
            }
        }
        if (swordReset == true && SwordResetTime >= AtkTime)
        {
            swordTrans = Sword.GetComponent<Transform>();
            Debug.Log("Reset");
            Sword.transform.Rotate(0, 0, 90);
            Sword.transform.position = new Vector3(swordTrans.position.x - 0, swordTrans.position.y + 1, swordTrans.position.z - 0);
            BoxColl.enabled = false;
            swordReset = false;
        }
    }
}
