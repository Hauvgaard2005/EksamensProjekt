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


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {





    }

    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        transform.up = Player.transform.position - transform.position;
    }

    public void Die()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
