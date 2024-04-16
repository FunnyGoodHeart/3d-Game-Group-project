using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowShoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] float shootSpeed = 1f;
    PlayerAttack plAtk;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (plAtk.bowAttack == true)
        {
            GameObject projectile = Instantiate(playerBullet);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
            projectile.transform.position = projectileSpawn.position;
            Vector3 rotation = projectile.transform.rotation.eulerAngles;
            projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * shootSpeed, ForceMode.Impulse);
            plAtk.bowAttack = false;
        }
    }
}
