using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack4 : MonoBehaviour
{
    public float shootCooldown;
    public GameObject Bullet;
    public float maxAngle = 0.7f;
    public float deltaAngle;
    private float currAngle;
    private bool isPositiveChange = true;
    private float currShoot = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.y > 0)
        {
            currAngle = -maxAngle;
        }
        else
        {
            currAngle = maxAngle;
            isPositiveChange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currShoot += Time.deltaTime;
        if (currShoot >= shootCooldown)
        {
            if (isPositiveChange)
            {
                if (currAngle == maxAngle)
                {
                    isPositiveChange = false;
                }
                else
                {
                    GameObject newBul = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 3),
                        new Quaternion());
                    PulpyScript mov = newBul.GetComponent<PulpyScript>();
                    mov.direction.x = -1;
                    mov.direction.y = currAngle;
                    mov.speed.x = 5;
                    mov.speed.y = 5;
                    currAngle += deltaAngle;
                    currShoot = 0;
                }
            }
            else
            {
                if (currAngle == -maxAngle)
                {
                    isPositiveChange = true;
                }
                else
                {
                    GameObject newBul = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, 3),
                        new Quaternion());
                    PulpyScript mov = newBul.GetComponent<PulpyScript>();
                    mov.direction.x = -1;
                    mov.direction.y = currAngle;
                    mov.speed.x = 5;
                    mov.speed.y = 5;
                    currAngle -= deltaAngle;
                    currShoot = 0;
                }
            }
        }
    }
  
}
