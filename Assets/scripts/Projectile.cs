
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private GameObject target;

    void start()
    {



    }

    void Update()
    {

        Vector3 displacement = target.transform.position - transform.position;
        displacement = displacement.normalized;
        transform.position += displacement * Time.deltaTime * 5f;
        Destroy(gameObject, Game.Instance.SpawnedPlayer.Range);

    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}


