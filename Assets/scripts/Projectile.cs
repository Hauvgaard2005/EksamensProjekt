using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float damage = 5f;
    public float range = 5f;



    void Update()
    {


        transform.Translate(Vector2.up * Time.deltaTime * 5f);



        if (transform.position.y > range)
        {
            DestroyProjectile();
        }

    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
