using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedDummy : MainUnitManager
{
    // INHERITANCE
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingSpeed = 1;
    [SerializeField] private float bulletSpeed = 200;
    [SerializeField] protected GameObject gunTransform;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Shoot();
    }

    void Update()
    {
        FollowPlayer();
    }

    void Shoot()
    {
        if (!GameManager.Instance.isGameOver)
        {
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay()
    {
        while (!GameManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(shootingSpeed);
            Rigidbody projectile = Instantiate(bulletPrefab, gunTransform.transform.position, gunTransform.transform.rotation).GetComponent<Rigidbody>();

            projectile.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        }
    }
}
