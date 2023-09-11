using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int numberOfEnemies = 5;
    private float spawnRadius = 100.0f;
    public Player SpawnedPlayer;
    public GameObject playerPrefab;

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

    public void Start()
    {

        GameObject go = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        SpawnedPlayer = go.GetComponent<Player>();

        Camera.main.transform.SetParent(SpawnedPlayer.transform);

        spawnEnemies();

    }

    void spawnEnemies()
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 asd = UnityEngine.Random.insideUnitCircle;
            Debug.Log(asd);

            Vector2 randomCircle = asd * spawnRadius;
            Debug.Log(randomCircle);

            Vector3 randomSpawnPoint = new Vector3(randomCircle.x, randomCircle.y, 0) + Game.Instance.SpawnedPlayer.transform.position;
            Debug.Log(randomSpawnPoint);

            Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }


    public void Update()
    {

    }
}