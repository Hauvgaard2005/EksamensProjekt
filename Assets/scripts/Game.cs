using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies = 5;
    private float spawnRadius = 10.0f;
    public Player SpawnedPlayer;
    public GameObject playerPrefab;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {

        GameObject go = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SpawnedPlayer = go.GetComponent<Player>();


        spawnEnemies();

    }

    void spawnEnemies()
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            Vector3 randomSpawnPoint = new Vector3(randomCircle.x, 0, randomCircle.y) + Game.Instance.SpawnedPlayer.transform.position;

            Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }


    public void Update()
    {

    }
}