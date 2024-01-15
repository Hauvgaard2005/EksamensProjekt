using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Diagnostics;

public class Game : MonoBehaviour
{
    public static Game Instance;

    //Enemy Spawner
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject sprinterPrefab;
    public Enemy spawnedEnemy;
    [SerializeField] private int numberOfMinions;
    [SerializeField] private int numberOfSprinters;
    private float spawnRadius = 100.0f;
    public List<Enemy> enemies = new List<Enemy>();

    public GameObject NearestEnemy;

    //hp bar
    public RectTransform CanvasRect;
    public Player SpawnedPlayer;
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;

    //upgrades
    public float CurrentSoulRange = 5f;

    //New Wave
    private float waveDuration = 10f;
    public float timer = 0f;
    public int currentWave = 0;

    //Day/Night
    public bool onEarth = true;

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
        print(currentWave);
        SpawnEnemies();
        print(currentWave);

    }

    public void Update()
    {
        //Wave
        timer += Time.deltaTime;

        //Enemy Spawner
        FindNearestEnemy();
        if (timer >= waveDuration)
        {
            currentWave++;
            timer = 0;
            SpawnEnemies();
        }

    }

    public void SpawnEnemies()
    {
        print("spawn enemies function called");
        switch (currentWave)
        {
            case 0:
                numberOfMinions = 5;
                break;
            case 1:
                numberOfMinions = 7;
                break;
            case 2:
                numberOfMinions = 10;
                numberOfSprinters = 2;
                break;
            case 3:
                numberOfMinions = 15;
                break;
            case 4:
                numberOfMinions = 20;
                break;
            case 5:
                numberOfMinions = 25;
                break;
            case 6:
                numberOfMinions = 30;
                break;
            case 7:
                numberOfMinions = 35;
                break;
            case 8:
                numberOfMinions = 40;
                break;
            case 9:
                numberOfMinions = 45;
                break;
            case 10:
                numberOfMinions = 50;
                break;
        }
        print(numberOfMinions);
        
        for (int i = 0; i < numberOfMinions; i++)
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            Vector3 randomSpawnPoint = new Vector3(randomCircle.x, randomCircle.y, 0) + Game.Instance.SpawnedPlayer.transform.position;

            GameObject go2 = Instantiate(minionPrefab, randomSpawnPoint, Quaternion.identity);
            spawnedEnemy = go2.GetComponent<Minion>();
            enemies.Add(spawnedEnemy);
            print("spawned minion");

        }
        
        for (int i = 0; i < numberOfSprinters; i++)
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            Vector3 randomSpawnPoint = new Vector3(randomCircle.x, randomCircle.y, 0) + Game.Instance.SpawnedPlayer.transform.position;

            GameObject go2 = Instantiate(sprinterPrefab, randomSpawnPoint, Quaternion.identity);
            spawnedEnemy = go2.GetComponent<Sprinter>();
            enemies.Add(spawnedEnemy);

        }
        
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