using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float speed = 2;
    public float damage;
    public GameObject xpPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private Collider2D ProjectileCollider;
    [SerializeField] private Collider2D EnemyCollider;


  
    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Game.Instance.SpawnedPlayer.transform.position, speed * Time.deltaTime);
        transform.up = Game.Instance.SpawnedPlayer.transform.position - transform.position;
    }

/*public void CollideWithProjectile()
    {
         if (EnemyCollider.IsTouching(Projectile.GetComponent<Collider2D>()))
        {
            Die();
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
            //spawn Xp ting ting
            Instantiate(xpPrefab, transform.position, Quaternion.identity);

            //remove enemy
            Destroy(this.gameObject);
            
            //remove object from list
        }
    }


}