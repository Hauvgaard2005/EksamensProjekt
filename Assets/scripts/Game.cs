using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Runtime.CompilerServices;

public class Game : MonoBehaviour
{
    public static Game Instance;
    [SerializeField] private GameObject enemyPrefab;
    public Enemy spawnedEnemy;
    [SerializeField] private int numberOfEnemies = 5;
    private float spawnRadius = 100.0f;
    public List<Enemy> enemies = new List<Enemy>();

    public RectTransform CanvasRect;
    public Player SpawnedPlayer;
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;
    public GameObject NearestEnemy;

    //upgrades
    public float CurrentGoldRange = 5f;

    //New Wave
    public float waveTimer; //Timeren mellem waves
    private float spawnInterval; //Intervallet mellem spawns
    private float spawnTimer; //Timeren
    public int waveDuration = 10; //Sekunder til næste wave

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {

        GameObject go = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SpawnedPlayer = go.GetComponent<Player>();

        Camera.main.transform.SetParent(SpawnedPlayer.transform);

        //Canvas
        CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        GameObject healthBar = Instantiate(healthBarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(CanvasRect.transform, false);
        healthBar.transform.position = new Vector3(healthBar.transform.position.x + 130, healthBar.transform.position.y + 20, healthBar.transform.position.z);
        healthBar.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        Player player = Game.Instance.SpawnedPlayer.GetComponent<Player>();
        Game.Instance.SpawnedPlayer.healthbar = healthBar.GetComponent<Healthbar>();

        SpawnNewWave();

    }

    public void Update()
    {
        FindNearestEnemy();
        if (spawnTimer <= 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
                Vector3 randomSpawnPoint = new Vector3(randomCircle.x, randomCircle.y, 0) + Game.Instance.SpawnedPlayer.transform.position;

                GameObject go2 = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
                spawnedEnemy = go2.GetComponent<Enemy>();
                enemies.Add(spawnedEnemy);

            }
            spawnTimer = spawnInterval;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            waveTimer -= Time.deltaTime;
        }
    }

    void SpawnNewWave()
    {
        spawnInterval = waveDuration;
        waveTimer = waveDuration;

    }



    //find nearest enemy//
    public void FindNearestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = SpawnedPlayer.transform.position;

        foreach (Enemy go in enemies)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                NearestEnemy = go.gameObject;
                distance = curDistance;
            }
        }
    }
}