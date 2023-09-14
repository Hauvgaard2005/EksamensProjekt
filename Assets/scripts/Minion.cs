using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : Enemy
{



    // Start is called before the first frame update
    void Start()
    {
        damage = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        Die();
        CollideWithProjectile();
    }
}
