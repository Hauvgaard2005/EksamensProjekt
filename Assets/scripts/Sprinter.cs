using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sprinter : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 10f;
        HP = 5;
        speed = 4f;

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        Die();

    }

}
