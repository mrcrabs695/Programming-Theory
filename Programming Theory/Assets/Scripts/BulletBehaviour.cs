using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * 0.5f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet Hit: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Dummy"))
        {
            //Destroy(other.gameObject);
            
        }

        Destroy(gameObject);
    }
}
