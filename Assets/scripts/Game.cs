using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int numberOfEnemies = 0;

    public GameObject playerSpawner;

    public void start()
    {

        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);


        for (int i = 0; i < numberOfEnemies; i++)
        {

           Instantiate(enemy);

           
        }

    }

    public void update()
    {

    }
}