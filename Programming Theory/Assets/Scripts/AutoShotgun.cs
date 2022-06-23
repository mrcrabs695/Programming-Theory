using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShotgun : GunShoot
{
    protected override void Shoot()
    {
        if(Input.GetButton("Fire1") && !GameManager.Instance.isGameOver)
        {
            Rigidbody projectile = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();

            projectile.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        } 
    }
}
