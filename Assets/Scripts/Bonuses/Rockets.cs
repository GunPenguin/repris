using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    public GameObject rocket;
    public float rate = 2f;
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
        if (other.tag == "Player" && (other.GetComponent<ShootScript>() != null))
        {
            ShootScript scr = other.GetComponent<ShootScript>();
            if (scr.shotPrefab != rocket.transform)
            {
                scr.shotPrefab = rocket.transform;
                scr.shootingRate = (scr.shootingRate + rate) / 2;
            }
            Destroy(this.gameObject);
        }
    }
}
