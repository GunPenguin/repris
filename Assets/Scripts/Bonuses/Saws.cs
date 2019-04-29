using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saws : MonoBehaviour
{
    public float rotateSpeed = 2.0f;
    public int damage;
    public float damageCooldown;
    private float currDamageTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        currDamageTimer += Time.deltaTime;
    }

    void Rotate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "Enemy" || (other.tag == "Boss")) && (currDamageTimer >= damageCooldown))
        {
            currDamageTimer = 0f;
            other.GetComponent<HealthScript>().Damage(damage);
        }
    }
}
