using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : Enemy
{

    public float Health = 100f;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //CollideWithProjectile();
        MoveToPlayer();
        Die();
        CollideWithProjectile();
    }
}
