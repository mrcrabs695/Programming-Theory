using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUnitManager : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody enemyRb;
    protected GameObject player;
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

    public virtual void FollowPlayer()
    {
        if (!GameManager.Instance.isGameOver)
        {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        
        enemyRb.AddForce(lookDirection * speed);
        transform.LookAt(player.transform);
        }

    }
}
