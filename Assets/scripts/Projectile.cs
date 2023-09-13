
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float damage = 20f;
    Rigidbody2D rb;

    void start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Vector3 displacement = Game.Instance.NearestEnemy.transform.position - transform.position;
        displacement = displacement.normalized;
        transform.position += displacement * Time.deltaTime * 5f;
        Destroy(gameObject, Game.Instance.SpawnedPlayer.Range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Game.Instance.NearestEnemy.GetComponent<Collider2D>())
        {
            Destroy(gameObject);
        }
    }


}


