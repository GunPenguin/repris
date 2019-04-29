using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownPrimitiveBehaviour : MonoBehaviour
{
    public float amplitude;
    public float speed;
    public bool isRotating;
    public float degreeChangeSpeed;
    public bool isChangingColor;
    public float colorChangeRate;
    public float colorChangeDeltaTime;
    public float maxY = 4.0f;
    private Rigidbody2D rb;
    private bool up = false;
    private float initialYposition;
    private float currentColorChangeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialYposition = rb.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            if (rb.position.y - initialYposition >= amplitude || (rb.position.y > maxY))
            {
                up = false;
            }
            else
            {
                rb.position = new Vector2(rb.position.x, rb.position.y +
                    ((rb.position.y + speed <= amplitude + rb.position.y) ? speed : amplitude));
            }
        }
        else
        {
            if (initialYposition - rb.position.y >= amplitude || (rb.position.y < -maxY))
            {
                up = true;
            }
            else
            {
                rb.position = new Vector2(rb.position.x, rb.position.y -
                    ((rb.position.y - speed >= rb.position.y - amplitude) ? speed : amplitude));
            }
        }
        if (isRotating)
        {
            rotate();
        }
        if (isChangingColor)
        {
            changeColor();
        }
    }

    void rotate()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), degreeChangeSpeed);
    }

    void changeColor()
    {
        currentColorChangeTime += Time.deltaTime;
        if (currentColorChangeTime >= colorChangeDeltaTime)
        {
            rb.GetComponent<Renderer>().material.color = new Color(
                rb.GetComponent<Renderer>().material.color.r + Random.Range(-colorChangeRate, colorChangeRate),
                rb.GetComponent<Renderer>().material.color.g + Random.Range(-colorChangeRate, colorChangeRate), 
                rb.GetComponent<Renderer>().material.color.b + Random.Range(-colorChangeRate, colorChangeRate));
            currentColorChangeTime = 0;
        }
    }
}
