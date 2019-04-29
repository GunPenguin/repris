using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{
    public int minCap = 25;
    public int maxCap = 125;
    public float cd = 0.1f;
    private float cdTimer = 0f;
    private float cnt;
    private bool up = true;
    private SpriteRenderer rnd;
    // Start is called before the first frame update
    void Start()
    {
        cnt = (minCap + maxCap) / 2;
        rnd = GetComponent<SpriteRenderer>();
        if (rnd.color.a > cnt)
        {
            up = false;
        }
        else
        {
            up = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rnd.color = new Color(25f / 255, 55f / 255, 77f / 255, 22f / 255);
        if (cdTimer > cd)
        {
            if (up)
            {
                if (cnt == maxCap)
                {
                    up = false;
                }
                else
                {

                    cnt++;
                }
            }
            else
            {
                if (cnt == minCap)
                {
                    up = true;
                }
                else
                {
                    cnt--;
                }
            }
            cdTimer = 0f;
            Color f = new Color(rnd.color.r, rnd.color.g, rnd.color.b, (cnt / 255f));   
           // GetComponent<SpriteRenderer>().color = f;

        }
        else
        {
            cdTimer += Time.deltaTime;
        }
    }
}
