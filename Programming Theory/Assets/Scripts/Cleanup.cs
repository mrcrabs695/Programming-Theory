using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -100 || transform.position.x >= 100 || transform.position.y <= -100 || transform.position.y >= 100 || transform.position.z <= -100 || transform.position.z >= 100)
        {
            Destroy(gameObject);
        }
        
    }
}
