using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Timers;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using System.Diagnostics;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;

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

    //Restart 
    public GameObject Restart;

    //upgrades
    [Header("Upgrades")]
    public float CurrentSoulRange = 5f;
    public GameObject Hell; //Canvas for upgrades
    public GameObject PlayerUI; //Canvas for PlayerUI

    //Wave
    private float hellDuration = 10f;
    [Header("Wave")]
    public TMP_Text HellTimer; //Visual timer you are in hell
    public TMP_Text CurrentWave;
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
            Destroy(gameObject);
        }

        GameObject go = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SpawnedPlayer = go.GetComponent<Player>();


        // HellTimer = GameObject. .FindGameObjectWithTag("HellTimer").GetComponent<Text>(); //Finder HellTimer Text

        Camera.main.transform.SetParent(SpawnedPlayer.transform);

    }

    void Start()
    {

        Hell.SetActive(false); //Canvas for upgrades bliver deaktiveret

        SpawnEnemies();
        print(currentWave);
        CurrentWave.text = "Wave: " + (currentWave + 1).ToString();

    }

    public void Update()
    {
        if (SpawnedPlayer.currentHealth <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(SpawnedPlayer.gameObject);
        }


        //Upgrade Wave
        if (onEarth == false)
        {

            if (hellDuration > 0)
            {
                hellDuration -= Time.deltaTime;
                HellTimer.text = "Time left in hell: " + Mathf.Round(hellDuration).ToString();
            }
            else
            {
                currentWave++;
                CurrentWave.text = "Wave: " + (currentWave + 1).ToString();
                hellDuration = 10;
                onEarth = true;
                Hell.SetActive(false); //Canvas for upgrades bliver deaktiveret
                PlayerUI.SetActive(true); //Canvas for PlayerUI bliver aktiveret igen
                SpawnEnemies();
                pickupTimer = 0;
            }

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
            Hell.SetActive(true); //Canvas for upgrades bliver aktiveret
            PlayerUI.SetActive(false); //Canvas for PlayerUI bliver deaktiveret


        }

    }

    public void SpawnEnemies()
    {
        print("spawn enemies function called");
        switch (currentWave)
        {
            case 0:
                numberOfMinions = 1;
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
                numberOfSprinters = 10;
                break;
            case 5:
                numberOfMinions = 25;
                numberOfSprinters = 12;
                break;
            case 6:
                numberOfMinions = 30;
                numberOfSprinters = 15;
                break;
            case 7:
                numberOfMinions = 35;
                numberOfSprinters = 27;
                break;
            case 8:
                numberOfMinions = 40;
                numberOfSprinters = 30;
                break;
            case 9:
                numberOfMinions = 45;
                numberOfSprinters = 32;
                break;
            case 10:
                numberOfMinions = 50;
                numberOfSprinters = 35;
                break;
            case 11:
                numberOfMinions = 55;
                numberOfSprinters = 37;
                break;
        }

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