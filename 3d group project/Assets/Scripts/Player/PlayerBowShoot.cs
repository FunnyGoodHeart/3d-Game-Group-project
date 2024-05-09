using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBowShoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerBullet; //bullet prefab
    [SerializeField] Transform projectileSpawn; //place where arrows spawn
    [SerializeField] float shootSpeed = 1f;
    public int bulletCount = 50;
    [SerializeField] float bulletLifetime = 4;
    [SerializeField] GameObject bulletSlideHold; //bullet ammount slider
    public int minBulletAdd = 10;
    public int maxBulletAdd = 15;
    Slider bulletSlider;
    public int maxBulletCount;
    PlayerAttack plAtk;
    void Start()
    {
        plAtk = player.GetComponent<PlayerAttack>();
        maxBulletCount = bulletCount;
        bulletSlider = bulletSlideHold.GetComponent<Slider>();
        bulletSlider.maxValue = maxBulletCount;
        bulletSlider.value = bulletCount;
    }

    void Update()
    {
        bulletSlider.value = bulletCount;
        if (plAtk.bowAttack == true && bulletCount > 0)
        {
            GameObject projectile = Instantiate(playerBullet);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
            projectile.transform.position = projectileSpawn.position;
            Vector3 rotation = projectile.transform.rotation.eulerAngles;
            projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * shootSpeed, ForceMode.Impulse);
            bulletCount -= 1;
            plAtk.bowAttack = false;
            Destroy(projectile, bulletLifetime);
        }
    }
}
