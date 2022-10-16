using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Projectile bullet;
    public Transform[] firePoints;
    public float shotPerSeconds;
    private float nextShotTime;

    private void Update()
    {
        Shoot();
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
