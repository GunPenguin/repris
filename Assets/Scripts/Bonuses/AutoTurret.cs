using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public float rate = 0.25f;
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
            if (scr.shoot != scr.autoShoot)
            {
                scr.shootingRate = (rate + scr.shootingRate) / 2;
                scr.shoot = scr.autoShoot;
            }
            Destroy(this.gameObject);
        }
    }
}
