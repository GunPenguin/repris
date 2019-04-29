using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack5 : MonoBehaviour
{
    public GameObject Bullet;
    public float shootCooldown;
    public float deltaY = 4f;
    private float timerShootCooldown = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerShootCooldown >= shootCooldown)
        {
            timerShootCooldown = 0;
            float _Y = Random.Range(-deltaY, deltaY);
            GameObject newBul = Instantiate(Bullet, new Vector3(transform.position.x, _Y, 3),
               new Quaternion());
            PulpyScript mov = newBul.GetComponent<PulpyScript>();
            mov.direction.y = -1/Mathf.Sqrt(2);
            mov.direction.x = -1;
            mov.speed.x = 5;
            mov.speed.y = 5;
            newBul = Instantiate(Bullet, new Vector3(transform.position.x, _Y, 3),
               new Quaternion());
            mov = newBul.GetComponent<PulpyScript>();
            mov.direction.y = 0;
            mov.direction.x = -1;
            mov.speed.x = 5;
            mov.speed.y = 5;
            newBul = Instantiate(Bullet, new Vector3(transform.position.x, _Y, 3),
               new Quaternion());
            mov = newBul.GetComponent<PulpyScript>();
            mov.direction.y = 1/Mathf.Sqrt(2);
            mov.direction.x = -1;
            mov.speed.x = 5;
            mov.speed.y = 5;
        }
        else
        {
            timerShootCooldown += Time.deltaTime;
        }
    }
}
