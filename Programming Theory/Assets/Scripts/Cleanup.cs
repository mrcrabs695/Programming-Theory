using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        // garbage collection so the game wont die from thousands of bullets existing
        if (transform.position.x <= -100 || transform.position.x >= 100 || transform.position.y <= -100 || transform.position.y >= 100 || transform.position.z <= -100 || transform.position.z >= 100)
        {
            Destroy(gameObject);
        }
        
    }
}
