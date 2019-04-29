using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardScript : MonoBehaviour
{
    public float Move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Move, transform.position.y, transform.position.z);
    }
}
