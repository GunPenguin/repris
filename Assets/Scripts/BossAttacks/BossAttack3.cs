using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack3 : MonoBehaviour
{

    public float shootCooldown;
    public GameObject Enemy;
    public float deltaY = 4f;
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
            float _Y = Random.Range(-deltaY, deltaY);
            Instantiate(Enemy, new Vector3(transform.position.x, _Y, 2), new Quaternion());
            currShoot = 0;
        }
        else
        {
            currShoot += Time.deltaTime;
        }
    }
}
