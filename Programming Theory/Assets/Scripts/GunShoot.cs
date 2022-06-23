using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !GameManager.Instance.isGameOver)
        {
            Rigidbody projectile = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();

            projectile.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        } 
    }
}
