﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterShooting : MonoBehaviour
{
    public float rateDecrease = 0.05f;
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
            if (other.GetComponent<ShootScript>() != null)
            {
                if (other.GetComponent<ShootScript>().shootingRate > other.GetComponent<ShootScript>().minShootingRate)
                {
                    other.GetComponent<ShootScript>().shootingRate -= rateDecrease;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
