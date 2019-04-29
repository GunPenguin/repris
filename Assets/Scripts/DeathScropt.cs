using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScropt : MonoBehaviour
{
    // Start is called before the first frame update
    public float deathTimer = 8;

    private Vector2 movement;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, deathTimer); 
    }
    
}
