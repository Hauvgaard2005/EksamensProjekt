using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float health = 100f;
    public float speed = 3.0f;
    int xp = 0;
    int level = 1;
    public Projectile projectilePrefab;
    [SerializeField] private Enemy Enemy;
    [SerializeField] private Collider2D playerCollider;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }

        if (playerCollider.IsTouching(Enemy.GetComponent<Collider2D>()))
        {
            Collison();
        }

        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }




    }

    private void MoveForward()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void MoveBackward()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position + transform.up;
    }

    private void Collison()
    {
        health -= 10f;


    }

    private void Pickup()
    {
        xp += 1;
    }

    private void LvlUp()
    {
        if (xp >= 5 * level)
        {
            level += 1;
            xp = 0;
        }
    }
}
