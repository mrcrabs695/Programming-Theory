using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int health = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            health -= 5;
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
