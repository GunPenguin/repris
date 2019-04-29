using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public List<GameObject> lst;
    public float enemySpawnCooldown;
    public float levelTimeMax;
    public Vector3 localCoord;
    public float offset = 3;
    public GameObject Boss;
    public GameObject Player;
    public GameObject heart;
    private Camera camera;
    private bool bossSpawned = false;
    private float spawnTime = 0;

    private int currPlayerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        currPlayerHealth = Player.GetComponent<HealthScript>().hp;
        updateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTimeMax > 0)
        {
            levelTimeMax -= Time.deltaTime;
            spawnTime += Time.deltaTime;
            if (spawnTime >= enemySpawnCooldown)
            {
                Spawn();
                spawnTime = 0;
            }
        }
        else
        {
            if (!bossSpawned)
            {
                deployBoss();
                bossSpawned = !bossSpawned;
            }
        }
        if (Player == null)
        {
            if (GameObject.FindGameObjectsWithTag("UI") != null)
            {
                GameObject[] go = GameObject.FindGameObjectsWithTag("UI");
                foreach (GameObject g in go)
                {
                    Destroy(g);
                }
            }
        }
        if ((Player != null) && (currPlayerHealth != Player.GetComponent<HealthScript>().hp))
        {
            updateHealth();
        }
    }

    void Spawn()
    {
        int chosenOne = Random.Range(0, lst.Count);
        float _ytemp = Random.Range(-4f, 4f);
        Instantiate(lst[chosenOne], new Vector3(camera.transform.position.x + camera.orthographicSize * Screen.width / Screen.height, _ytemp, 0),
            new Quaternion());
    }
    void deployBoss()
    {
        Instantiate(Boss, new Vector3(camera.transform.position.x + camera.orthographicSize * Screen.width / Screen.height + 6, 0, 0),
            new Quaternion());
    }
    void updateHealth()
    {
        currPlayerHealth = Player.GetComponent<HealthScript>().hp;
        Vector3 tmpCoord = localCoord;
        if (GameObject.FindGameObjectsWithTag("UI") != null)
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("UI");
            foreach(GameObject g in go)
            {
                Destroy(g);
            }
        }
        for (int i = 0; i < currPlayerHealth; i++)
        {
            GameObject gm = Instantiate(heart, camera.transform);
            gm.transform.position = new Vector3(camera.transform.position.x - tmpCoord.x, camera.transform.position.y - tmpCoord.y, 2 );
            gm.name = "Heart";
            tmpCoord = new Vector3(tmpCoord.x + offset, tmpCoord.y, 2);
        }
    }
}
