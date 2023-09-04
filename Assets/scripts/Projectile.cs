using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float damage = 5f;
    public float Range = 1f;



    void Update()
    {


        transform.Translate(Vector2.up * Time.deltaTime * 5f);


    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
