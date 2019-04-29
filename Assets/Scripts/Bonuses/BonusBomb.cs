using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBomb : MonoBehaviour
{
    public GameObject bombThrower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && (other.GetComponent<ShootScript>() != null))
        {
            Instantiate(bombThrower, other.transform);
            Destroy(this.gameObject);
        }
    }
}
