
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{


    public float damage = 10f;
    Transform target;

    void Start()
    {
        target = Game.Instance.NearestEnemy.transform;
    }


    void Update()
    {

        if (target != null)
        {

            if (target.gameObject.activeSelf)
            {

                Vector3 displacement = target.position - transform.position;
                displacement = displacement.normalized;
                transform.position += displacement * Time.deltaTime * 5f;

            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

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


