using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedDummy : MainUnitManager
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingSpeed = 1;
    [SerializeField] protected GameObject mainTransform;

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

    public override void FollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);
        transform.LookAt(player.transform);

    }

    IEnumerator ShootDelay()
    {
        while (!GameManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(shootingSpeed);
            Instantiate(bulletPrefab, mainTransform.transform.position, mainTransform.transform.rotation);
        }
    }
}
