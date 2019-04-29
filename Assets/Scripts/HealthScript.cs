using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp = 1;
    public float invulerabilityTime = 1f;
    public float tickTime = 0.2f;
    public bool isEnemy = true;
    public Color tickColor;
    public bool isDmgAnimation;
    public bool isDeathAnimation;
    public int MAXHP = 7;

    private Animation dmgAnim;
    private float invTimer;
    private float tickTimer;
    private float returnColorTimer = 0;
    private Color mainColor;
    // Start is called before the first frame update
    void Start()
    {
        mainColor = GetComponent<SpriteRenderer>().color;
        tickTimer = tickTime;
        invTimer = invulerabilityTime;
        dmgAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged())
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= tickTime)
            {
                tickTimer = 0;
                if (GetComponent<SpriteRenderer>().color == mainColor)
                     GetComponent<SpriteRenderer>().color = tickColor;
                else
                    GetComponent<SpriteRenderer>().color = mainColor;

            }
        }
        else
        {
            if (GetComponent<SpriteRenderer>().color != mainColor)
            {
                returnColorTimer += Time.deltaTime;
                if (returnColorTimer >= tickTimer)
                {
                    GetComponent<SpriteRenderer>().color = mainColor;
                }
            }
            else
            {
                returnColorTimer = 0;
            }
        }
        invTimer += Time.deltaTime;
    }

    public void Damage(int damageCount)
    {
        
        hp -= damageCount;
        if (isDmgAnimation)
        {
            //dmgAnim["Explosion1"].speed = 6;
            dmgAnim.Play();
        }
        invTimer = 0;
        if (hp <= 0)
        {
            if (isDeathAnimation)
            {

            }
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerBulletScript shot = other.gameObject.GetComponent<PlayerBulletScript>();
        if (shot != null && (invTimer >= invulerabilityTime))
        {
            if (shot.isEnemyShot != GetComponent<HealthScript>().isEnemy)
            {
                Damage(shot.damage);
            Destroy(shot.gameObject);
            }
        }
    }

    bool isDamaged()
    {
        return invTimer < invulerabilityTime;
    }
}
