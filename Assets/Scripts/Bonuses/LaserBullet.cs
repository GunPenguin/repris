using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public int damage = 2;
    public bool isEnemyShot = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || (other.tag == "Boss"))
        {
            other.GetComponent<HealthScript>().Damage(damage);
        }
    }
}
