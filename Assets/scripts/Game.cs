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
    [Header("Enemy Spawner")]
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject sprinterPrefab;
    public Enemy spawnedEnemy;
    [SerializeField] private int numberOfMinions;
    [SerializeField] private int numberOfSprinters;
    private float spawnRadius = 100.0f;
    public List<Enemy> enemies = new List<Enemy>();

    public GameObject NearestEnemy;


    public Player SpawnedPlayer;
    public GameObject playerPrefab;


    //upgrades
    [Header("Upgrades")]
    public float CurrentSoulRange = 5f;
    public GameObject Hell; //Canvas for upgrades

    //Wave
    private float hellDuration = 10f;
    [Header("Wave")]
    public float hellTimer = 0f;
    public int currentWave = 0;
    public bool onEarth = true;
    private float pickupDuration = 5f;
    public float pickupTimer = 0f;



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


        Player player = Game.Instance.SpawnedPlayer.GetComponent<Player>();
        
        print(currentWave);
        SpawnEnemies();
        print(currentWave);

    }

    public void Update()
    {
        //Upgrade Wave
        if (onEarth == false)
        {
            hellTimer += Time.deltaTime;
        }

        if (hellTimer >= hellDuration)
        {
            currentWave++;
            hellTimer = 0;
            onEarth = true;
            Hell.SetActive(false);
            SpawnEnemies();
            pickupTimer = 0;
        }

        //Enemy Spawner
        FindNearestEnemy();
        if (enemies.Count == 0)
        {
            pickupTimer += Time.deltaTime;
            if (pickupTimer >= pickupDuration)
            {
                pickupTimer = 0;
                onEarth = false;
            }
        }

        if (onEarth == false)
        {
            Hell.SetActive(true);


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
                numberOfSprinters = 5;
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