using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float speed = 2;
    public float damage = 1;
    public GameObject soulPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private Projectile projectile;



    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Game.Instance.SpawnedPlayer.transform.position, speed * Time.deltaTime);
        transform.up = Game.Instance.SpawnedPlayer.transform.position - transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            HP -= Game.Instance.SpawnedPlayer.damage;
        }

    }


    public void Die()
    {
        if (HP <= 0)
        {

            //remove enemy
            Game.Instance.enemies.Remove(this);
            Destroy(this.gameObject);
            //spawn Soul ting ting
            GameObject go = Instantiate(soulPrefab, transform.position, Quaternion.identity);
            Soul soul = go.GetComponent<Soul>();
            soul.SetPickupDistance(Game.Instance.CurrentSoulRange);


        }
    }

    // method triggers on collision//


}