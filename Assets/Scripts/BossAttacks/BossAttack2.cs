using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2 : MonoBehaviour
{
    public GameObject Player;
    public float shootCooldown;
    public GameObject Bullet;
    private float currShoot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currShoot >= shootCooldown)
        {
            Vector3 currPosition;
            currPosition = Player.transform.position;
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject newBul = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 3),
                new Quaternion());
                PulpyScript mov = newBul.GetComponent<PulpyScript>();
                currPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
                Vector3 vec = currPosition - transform.position;
                vec.Normalize();
                mov.direction.x = vec.x;
                mov.direction.y = vec.y;
                mov.speed.x = 5;
                mov.speed.y = 5;
                currShoot = 0;

            }
        }
        else
        {
            currShoot += Time.deltaTime;
        }

    }
}
