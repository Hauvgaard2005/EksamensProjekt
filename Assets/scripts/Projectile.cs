
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    public float damage = 5f;
    public float Range = 1f;
    [SerializeField] private GameObject target;

    void start()
    {



    }

    void Update()
    {

        Vector3 displacement = Game.Instance.spawnedEnemy.transform.position - transform.position;
        displacement = displacement.normalized;
        transform.position += displacement * Time.deltaTime * 5f;
        Destroy(gameObject, Range);

    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}


