using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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
            if (other.GetComponent<HealthScript>().MAXHP > other.GetComponent<HealthScript>().hp)
            {
                other.GetComponent<HealthScript>().hp++;
                Destroy(this.gameObject);
            }
        }
    }
}
