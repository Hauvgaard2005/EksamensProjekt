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
    [SerializeField] private Projectile projectile;



    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Game.Instance.SpawnedPlayer.transform.position, speed * Time.deltaTime);
        transform.up = Game.Instance.SpawnedPlayer.transform.position - transform.position;
    }

    public void CollideWithProjectile()
    {
        if (Game.Instance.spawnedEnemy.GetComponent<Collider2D>().IsTouching(projectile.GetComponent<Collider2D>()))
        {
            Destroy(this.gameObject);
        }

    }

    public void Die()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}