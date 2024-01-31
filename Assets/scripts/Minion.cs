using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Minion : Enemy
{


    public EdgeCollider2D TerrainCollider;
    
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        damage = 5f;
        HP = 15;
        speed = 2f;
        TerrainCollider = GameObject.FindGameObjectWithTag("Terrain").GetComponent<EdgeCollider2D>();
        Physics2D.IgnoreCollision(TerrainCollider, GetComponent<EdgeCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        Die();
        FlipSprite();

    }

}
