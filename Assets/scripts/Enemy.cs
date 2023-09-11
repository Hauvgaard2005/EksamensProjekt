using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float speed = 2;
    public float damage;
    [SerializeField] private GameObject Player;
    [SerializeField] private Collider2D ProjectileCollider;
    [SerializeField] private Collider2D EnemyCollider;


  
    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        transform.up = Player.transform.position - transform.position;
    }

/*public void CollideWithProjectile()
    {
         if (EnemyCollider.IsTouching(Projectile.GetComponent<Collider2D>()))
        {
            Collison();
        }
         if (playerCollider.IsTouching(Enemy.GetComponent<Collider2D>()))
        {
            Collison();
        }
  
    }
    */
    public void Die()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}