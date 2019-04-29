using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float attackCooldown;
    public List<GameObject> attacks;
    public float attackY = 20f;
    public float deployTime = 3;
    private float attackTime = 0f;
    private float currDepTime;
    private Vector3 begPos;
    private bool isDeployed = false;
    private bool isDead = false;
    private const int MAX_ATTACKS = 5;
    // Start is called before the first frame update
    void Start()
    {
        begPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeployed)
        {
            transform.position += new Vector3(- 0.03f, 0, 0);
            currDepTime += Time.deltaTime;
        }
        if (currDepTime >= deployTime) { isDeployed = true; }
        if (currDepTime >= deployTime) { isDeployed = true; }
        if (isDeployed && (attackTime >= attackCooldown))
        {
            attack();
            attackTime = 0;
        }
        if (isDeployed)
        {

            transform.position += new Vector3(0.0f, 0, 0);
        }
        attackTime += Time.deltaTime;
    }

    void attack()
    {
        int nextAttack = Random.Range(0, attacks.Count);
        float _Y = Random.Range(-attackY, attackY);
        if (nextAttack != 3 && (nextAttack != 5))
        {
            Instantiate(attacks[nextAttack], new Vector3(transform.position.x, _Y, 0), new Quaternion(), this.transform);
        }
        else
        {
            Instantiate(attacks[nextAttack], new Vector3(transform.position.x, 0, 0), new Quaternion(), this.transform);
        }
        if (nextAttack == 0)
        {
            attackTime = attackCooldown - 2;
        }
    }
}
