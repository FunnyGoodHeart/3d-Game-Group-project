using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour
{
    GameObject player;
    public int enemyAmmoDamage = 1;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
