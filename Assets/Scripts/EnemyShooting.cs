using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private ShootScript shoot;
    // Start is called before the first frame update
    void Awake()
    {
        shoot = GetComponent<ShootScript>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot != null && shoot.CanAttack)
        {
            shoot.Attack(true);
        }
    }
}
