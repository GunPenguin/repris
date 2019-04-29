using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : MonoBehaviour
{
    public float rate = 1.5f;
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
            if (scr.bulletDeploy != scr.trippleDeploy)
            {
                scr.bulletDeploy = scr.trippleDeploy;
                scr.shootingRate = (scr.shootingRate + rate) / 2;
            }
            Destroy(this.gameObject);
        }
    }
}
