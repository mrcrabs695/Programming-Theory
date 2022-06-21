using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnitManager : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
        FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);
        transform.LookAt(player.transform);

    }
}
