using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool callOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (callOnce)
            {
                Instantiate(this, new Vector3(transform.position.x + 80, transform.position.y, transform.position.z), new Quaternion());
            }
        }
    }
}
