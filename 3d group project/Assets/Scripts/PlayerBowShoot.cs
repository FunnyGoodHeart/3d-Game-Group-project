using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowShoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBullet;
    [SerializeField] float shootSpeed = 1f;
    PlayerAttack plAtk;
    float z = 0;
    float x = 0;
    float y = 0;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 shootDir = mousePosition - transform.position;
        shootDir.Normalize();
        z = shootDir.z;
        x = shootDir.x;
        y = shootDir.y;
        if (plAtk.bowAttack == true)
        {
            GameObject bullet = Instantiate(playerBullet,transform.position, Quaternion.identity) as GameObject;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(shootDir * shootSpeed);
            plAtk.bowAttack = false;
        }
    }
}
