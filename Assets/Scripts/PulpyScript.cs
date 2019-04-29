using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public int contactDamage;
    
    private Vector2 movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
       // 
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
       //Destroy(this.gameObject, deathTimer);
    }
    void Destroy()
    {
        if (GetComponent<DropScript>() != null)
        {
            DropScript dsp = GetComponent<DropScript>();
            if (GetComponent<Collider2D>() != null)
            {
                dsp.drop(GetComponent<Collider2D>().bounds.size.y / 2);
            }
            else
            {
                dsp.drop(0.05f);
            }
        }
    }
}
