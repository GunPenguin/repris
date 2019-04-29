using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public float invulerabilityTime = 2f;
    private Vector2 movement;
    private float invTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        if (Mathf.Approximately(inputX, 0) || ((inputX > 0) && (inputX < 0.1)))
        {
            transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, 0);
        }
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            ShootScript shot = GetComponent<ShootScript>();
            if (shot != null)
            {
                shot.Attack(false);
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GetComponent<HealthScript>().Damage(
                other.GetComponent<PulpyScript>().contactDamage);
            Destroy(other.gameObject);
        }
        if (other.tag == "Boss")
        {
            GetComponent<HealthScript>().Damage(9999);
            other.GetComponent<HealthScript>().Damage(5);
        }
    }
}
