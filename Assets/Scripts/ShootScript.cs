using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.25f;
    public bool shootRight = true;
    public float minShootingRate = 0.1f;
    // Start is called before the first frame update
    private float shootCooldown = 0f;
    public delegate void shootPnt(bool isEnemy);
    public delegate void bulletDeployPnt(Transform pos);
    public bulletDeployPnt bulletDeploy;
    public shootPnt shoot;
    void Start()
    {
        shoot = defaultShoot;
        bulletDeploy = defaultDeploy;
        if (this.gameObject.tag == "Player")
        {
            //shoot = autoShoot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;
            shoot(isEnemy);
            bulletDeploy(transform);
        }
    }
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

    public void defaultShoot(bool isEnemy)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        PlayerBulletScript shot = shotTransform.gameObject.GetComponent<PlayerBulletScript>();
        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
        }

        PulpyScript move = shotTransform.gameObject.GetComponent<PulpyScript>();
        if (move != null)
        {
            if (shootRight)
            {
                move.direction = this.transform.right;
            }
            else
            {
                move.direction = this.transform.right * -1;
            }
        }
    }

    public void autoShoot(bool isEnemy)
    {
        Transform shotTransform = Instantiate(shotPrefab);
        GameObject[] enem = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        float minDist = Mathf.Infinity;
        GameObject minObj = new GameObject("tmp");
        Vector3 currPos = new Vector3();
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            currPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        if (enem != null || (bosses != null))
        {
            foreach (GameObject g in enem)
            {
                if (Vector3.Distance(currPos, g.transform.position) < minDist)
                {
                    if (currPos.x < g.transform.position.x)
                    {
                        minDist = Vector3.Distance(currPos, g.transform.position);
                        minObj = g;
                    }
                }
            }
            foreach (GameObject g in bosses)
            {
                if (Vector3.Distance(currPos, g.transform.position) < minDist)
                {
                    minDist = Vector3.Distance(currPos, g.transform.position);
                    minObj = g;
                }
            }
            Vector3 vec = new Vector3(1, 0, 0);
            if (minObj.transform.position.x 
                 > currPos.x)
            {
                vec = minObj.transform.position - currPos;
                vec.Normalize();
            }
            shotTransform.position = currPos;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            shotTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            PulpyScript mov = shotTransform.GetComponent<PulpyScript>();
            mov.direction.x = vec.x;
            mov.direction.y = vec.y;
            mov.speed.x = 20;
            mov.speed.y = 20;
            GameObject onDel = GameObject.Find("tmp");
            Destroy(onDel);
        }
    }


    public void defaultDeploy(Transform pos)
    {

    }

    public void trippleDeploy(Transform pos)
    {
        Transform shotTransformUp = Instantiate(shotPrefab);
        Transform shotTransformDown = Instantiate(shotPrefab);
        shotTransformDown.transform.position = transform.position;
        shotTransformUp.transform.position = transform.position;
        shotTransformUp.rotation = Quaternion.Euler(new Vector3(0, 0, 45/2));
        shotTransformDown.rotation = Quaternion.Euler(new Vector3(0, 0, -45/2));
        PulpyScript movUp = shotTransformUp.GetComponent<PulpyScript>();
        PulpyScript movDown = shotTransformDown.GetComponent<PulpyScript>();
        movUp.direction.x = 1 / Mathf.Sqrt(2);
        movUp.direction.y = 1 / Mathf.Sqrt(2);
        movUp.speed.y = movUp.speed.x / 4;
        movDown.direction.x = 1 / Mathf.Sqrt(2);
        movDown.direction.y = 1 / -Mathf.Sqrt(2);
        movDown.speed.y = movDown.speed.x / 4;
    }
    
}
