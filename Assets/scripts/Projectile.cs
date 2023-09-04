using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float damage = 5f;
    public float Range = 1f;
    public Enemy enemy;

    void start()
    {
        Vector2 displacement = enemy.transform.position - transform.position;
        displacement = displacement.normalized;

    }

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 5f);
        Destroy(gameObject, Range);


    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
