using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikiTimBossFight : MonoBehaviour
{
    [SerializeField] int bossHealth = 100;
    Animator ani;
    float timer;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
