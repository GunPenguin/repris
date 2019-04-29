using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public int damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Enemy" || (other.tag == "Boss"))
        {
            if (other.GetComponent<HealthScript>() != null)
            {
                other.GetComponent<HealthScript>().Damage(damage);
                Destroy(this.gameObject);
            }
            //TODO EXPLOSION
        }
    }
}
