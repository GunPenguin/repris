using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    public List<GameObject> listDrop;
    public float dropChance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        drop(0.5f);
    }
    public void drop(float boundsY)
    {
        float isDrop = Random.Range(0f, 100f);
        int currDrops = 0;
        if (isDrop < dropChance)
        {
            int dropElement = Random.Range(0, listDrop.Count);
            float deltaY = Random.Range(-boundsY, boundsY);
            Instantiate(listDrop[dropElement], new Vector3(transform.position.x, transform.position.y + deltaY, 3),
                new Quaternion());
            
            currDrops++;
            isDrop = Random.Range(0f, 100f);
        }
    }
}
