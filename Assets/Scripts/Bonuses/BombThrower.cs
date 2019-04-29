using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrower : MonoBehaviour
{
    public float bombCooldown = 2.0f;
    public GameObject bomb;
    public float forwardForce;
    private float bombTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer += Time.deltaTime;
        if (bombCooldown <= bombTimer)
        {
            GameObject go = Instantiate(bomb, transform.position, new Quaternion());
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(forwardForce + transform.parent.GetComponent<Rigidbody2D>().velocity.x * 50,
                transform.parent.GetComponent<Rigidbody2D>().velocity.y * 50));
            bombTimer = 0;
        }
    }
}
