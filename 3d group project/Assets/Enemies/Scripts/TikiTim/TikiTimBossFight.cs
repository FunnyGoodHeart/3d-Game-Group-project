using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class TikiTimBossFight : MonoBehaviour
{
    [Header("Connections")]
    [SerializeField] GameObject player;
    [SerializeField] int bossHealth = 100;
    [SerializeField] int bossSpeedHard = 10;
    [SerializeField] GameObject bossArea;
    [SerializeField] GameObject doorBlock;
    [SerializeField] Canvas WinScreen;

    [Header("showing Boss Health & Text")]
    [SerializeField] GameObject bossHealthSliderPart;
    [SerializeField] GameObject backGroundPart;
    [SerializeField] GameObject fillPart;
    [SerializeField] GameObject bossText;

    [Header("Attacking")]
    public int bossDmg = 25;
    [SerializeField] int bossHitCoolDown = 3;
    [SerializeField] GameObject hitBoxBox;
    [SerializeField] GameObject playerInRange;

    //sliders
    Slider boosHealthSlider;
    TextMeshProUGUI bossHealthText;
    Image backGroundSlider;
    Image fillSlider;

    //connects
    InPlayerRange plRan;
    BoxCollider hitBox;
    InBossArena BA;
    NavMeshAgent agent;
    PlayerAttack plAtk;
    Animator ani;
    MeshRenderer dBMesh;
    MeshCollider dBColli;

    //ect
    int slapOrStomp;
    bool dead = false;
    bool isAttacking = false;
    bool cDActive = false;
    bool justHit = false;
    bool bossHealthShowing = false;
    bool win = false;
    int maxBossHealth;
    float timer;
    float winUptimer;

    //hard mode
    HardModeSkull hardMode;
    bool hardModeStarted = false;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        BA = bossArea.GetComponent<InBossArena>();
        hitBox = hitBoxBox.GetComponent<BoxCollider>();
        plRan = playerInRange.GetComponent<InPlayerRange>();
        dBMesh = doorBlock.GetComponent<MeshRenderer>();
        dBColli = doorBlock.GetComponent<MeshCollider>();


        hitBox.enabled = false;
        slapOrStomp = Random.Range(1, 3);

        boosHealthSlider = bossHealthSliderPart.GetComponent<Slider>();
        backGroundSlider = backGroundPart.GetComponent<Image>();
        fillSlider = fillPart.GetComponent<Image>();
        bossHealthText = bossText.GetComponent<TextMeshProUGUI>();

        maxBossHealth = bossHealth;
        boosHealthSlider.maxValue = bossHealth;
        boosHealthSlider.value = bossHealth;
        backGroundSlider.enabled = false;
        fillSlider.enabled = false;
        bossHealthText.enabled = false;
        WinScreen.enabled = false;

        GameObject Skull = GameObject.Find("TheHardModeSkull");
        hardMode = Skull.GetComponent<HardModeSkull>();
    }

    void Update()
    {
        winUptimer += Time.deltaTime;
        if (hardMode.startTheFire == true && hardModeStarted == false)
        {
            maxBossHealth *= hardMode.timesDiffuculty;
            bossHealth = maxBossHealth;
            boosHealthSlider.maxValue = maxBossHealth;
            boosHealthSlider.value = bossHealth;
            bossDmg *= hardMode.timesDiffuculty;
            bossHitCoolDown -= 1;
            agent.speed = bossSpeedHard;
            hardModeStarted = true;
        }
            Debug.Log(isAttacking);
        timer += Time.deltaTime;
        if (justHit == true && cDActive == false)
        {
            Debug.Log("cd Start");
            //isAttacking = false;
            cDActive = true;
            hitBox.enabled = false;
            timer = 0;
        }
        else if(cDActive == true && timer >= bossHitCoolDown)
        {
            Debug.Log("CD finish");
            justHit = false;
            cDActive = false;
            isAttacking = false;
            ani.SetBool("IsAttacking", false);
        }
        else if (BA.inTheBossArea == true && isAttacking == false && dead == false)
        {
            Debug.Log("moving");
            agent.destination = player.transform.position;
            ani.SetFloat("Speed", agent.destination.magnitude);

            if (bossHealthShowing == false)
            {
                backGroundSlider.enabled = true;
                fillSlider.enabled = true;
                bossHealthText.enabled = true;
            }
        }
        BossAttacking();
        if (dead == false && bossHealth <= 0)
        {
            Transform stay = GetComponent<Transform>();
            agent.destination = stay.transform.position;
            ani.SetBool("IsDieing", true);
            dBMesh.enabled = false;
            dBColli.enabled = false;
            WinScreen.enabled = true;
            backGroundSlider.enabled = false;
            fillSlider.enabled = false;
            bossHealthText.enabled = false;
            win = true;
            winUptimer = 0;
            dead = true;
        }
        if(winUptimer >= 5 && win == true)
        {
            WinScreen.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            bossHealth -= plAtk.playerBowATK;
            boosHealthSlider.value = bossHealth;
            
            if (BA.inTheBossArea == false)
            {
                BA.inTheBossArea = true;
            }
        }
        if (other.gameObject.tag == "PlayerSword")
        {
            bossHealth -= plAtk.playerBowATK;
            boosHealthSlider.value = bossHealth;
        }
    }
    void BossAttacking()
    {
        if (justHit == false && plRan.playerIsInRange == true && dead == false)
        {
            Debug.Log("attacking");
            isAttacking = true;
            ani.SetBool("IsAttacking", true);
            hitBox.enabled = true;
            if(slapOrStomp == 1)
            {
                Debug.Log("slap");
                ani.SetTrigger("IsSlapping");
            }
            else if(slapOrStomp == 2)
            {
                Debug.Log("stomp");
                ani.SetTrigger("IsStomping");
            }
            slapOrStomp = Random.Range(1, 3);
            justHit = true;
        }
    }
}
