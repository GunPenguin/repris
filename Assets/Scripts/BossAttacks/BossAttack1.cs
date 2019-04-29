using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 3), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
