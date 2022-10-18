using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Projectile bullet;
    public Transform[] firePoints;
    public float shotPerSeconds;
    private float nextShotTime;

    public int level;
    public int maxLevel;
    public int upgradeCost;
    public Animator anim;
    public GameObject lvEffect;
    public Text UpgradeCostText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpgradeCostText.text = upgradeCost.ToString();
    }

    public void AddLevel()
    {
        if (upgradeCost <= GameManager.instance.currentGold && level <maxLevel)
        {
            level++;
            GameManager.instance.ReduceGold(upgradeCost);
            anim.SetTrigger("UG");
            shotPerSeconds++;
            Instantiate(lvEffect, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(10);
        }
    }

    public void Shoot()
    {
        if(nextShotTime <= Time.time)
        {
            foreach(Transform firePoints in firePoints)
            {
                Projectile _bulet = Instantiate(bullet, firePoints.position, firePoints.rotation);
            }

            nextShotTime = Time.time + (1/shotPerSeconds);
        }
    }
}
