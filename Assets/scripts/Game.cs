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

    public RectTransform CanvasRect;
    public Player SpawnedPlayer;
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;

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

        CanvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();

        //Add healthbar to canvas
        GameObject healthBar = Instantiate(healthBarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(CanvasRect.transform, false);

        //move healthbar to bottom left of screen
        healthBar.transform.position = new Vector3(healthBar.transform.position.x + -115, healthBar.transform.position.y + -160, healthBar.transform.position.z);


        Player player = Game.Instance.SpawnedPlayer.GetComponent<Player>();
        Game.Instance.SpawnedPlayer.healthbar = healthBar.GetComponent<Healthbar>();

        spawnEnemies();

    }

    void spawnEnemies()
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * spawnRadius;
            Vector3 randomSpawnPoint = new Vector3(randomCircle.x, randomCircle.y, 0) + Game.Instance.SpawnedPlayer.transform.position;

            Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }


    public void Update()
    {

    }
}