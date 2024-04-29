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
    [SerializeField] GameObject bossArea;

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

    //ect
    int slapOrStomp;
    bool isAttacking = false;
    bool cDActive = false;
    bool justHit = false;
    bool bossHealthShowing = false;
    float timer;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        BA = bossArea.GetComponent<InBossArena>();
        hitBox = hitBoxBox.GetComponent<BoxCollider>();
        plRan = playerInRange.GetComponent<InPlayerRange>();

        hitBox.enabled = false;
        slapOrStomp = Random.Range(1, 3);

        boosHealthSlider = bossHealthSliderPart.GetComponent<Slider>();
        backGroundSlider = backGroundPart.GetComponent<Image>();
        fillSlider = fillPart.GetComponent<Image>();
        bossHealthText = bossText.GetComponent<TextMeshProUGUI>();
        boosHealthSlider.maxValue = bossHealth;
        boosHealthSlider.value = bossHealth;
        backGroundSlider.enabled = false;
        fillSlider.enabled = false;
        bossHealthText.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 moveDir = player.transform.position - transform.position;
        BossAttacking();
        if (justHit == true && cDActive == false)
        {
            isAttacking = false;
            cDActive = true;
            timer = 0;
        }
        else if(cDActive == true || timer >= bossHitCoolDown)
        {
            justHit = false;
        }
        if (BA.inTheBossArea == true && isAttacking == false) //starts chaisng player and start chase timer
        {
            agent.destination = player.transform.position;
            ani.SetFloat("Speed", agent.destination.magnitude);
            
            if (bossHealthShowing == false)
            {
                backGroundSlider.enabled = true;
                fillSlider.enabled = true;
                bossHealthText.enabled = true;
            }
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
    }
    void BossAttacking()
    {
        if (justHit == false && plRan.playerIsInRange == true)
        {
            isAttacking = true;
            ani.SetBool("IsAttacking", true);
            hitBox.enabled = true;
            if(slapOrStomp == 1)
            {
                ani.SetTrigger("IsSlapping");
            }
            else if(slapOrStomp == 2)
            {
                ani.SetTrigger("IsStomping");
            }
            slapOrStomp = Random.Range(1, 3);
            justHit = true;
        }
    }
}
