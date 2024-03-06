using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : Enemy
{


    
    
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        damage = 5f;
        HP = 15;
        speed = 2f;
        

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        Die();
        FlipSprite();

    }

}
