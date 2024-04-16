using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBowShoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBullet;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] float shootSpeed = 1f;
    [SerializeField] int bulletCount = 50;
    [SerializeField] GameObject stats;
    int maxBulletCount;
    Slider bulletSlider;
    PlayerAttack plAtk;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
        maxBulletCount = bulletCount;
        bulletSlider = stats.GetComponentInChildren<Slider>();
        bulletSlider.maxValue = maxBulletCount;
        bulletSlider.value = bulletCount;
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
