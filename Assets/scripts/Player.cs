using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class Player : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public float speed = 3.0f;
    public int gold = 0;
    private bool isTakingDamage = false;
    public Projectile projectilePrefab;
    [SerializeField] private Enemy Enemy;
    private bool _invincible = false;


    public Healthbar healthbar;

    //Projectile upgrades
    public float damage = 5f;
    public float Range = 1f;
    public float reloadSpeed = 1f;





    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);


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



        /*if (Game.Instance.SpawnedPlayer.GetComponent<Collider2D>().IsTouching(Game.Instance.spawnedEnemy.GetComponent<Collider2D>()))
        {
            Collison();
        }
        */
        if (currentHealth <= 0f)
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
        projectile.transform.position = transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Enemy enm = other.GetComponent<Enemy>();
            TakeDamage(enm.damage);
            print("trigger Taking damage");
        }
        else
        {
            print("no enemy");
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enm = other.gameObject.GetComponent<Enemy>();
            TakeDamage(enm.damage);
            print("col Taking damage");
            //apply force to player relative to collision
            Vector2 force = transform.position - other.transform.position;
            GetComponent<Rigidbody2D>().AddForce(force * 10f);
        }
        else
        {
            print("no enemy");
        }
    }



    public void TakeDamage(float damageAmount)
    {
        /*
        if(isTakingDamage){
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            healthbar.SetHealth(currentHealth);
        }
        */
        if (!_invincible)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            healthbar.SetHealth(currentHealth);
            StartCoroutine(InvincibilityFrames());
        }

    }

    private IEnumerator InvincibilityFrames()
    {
        _invincible = true;
        yield return new WaitForSeconds(1f);
        _invincible = false;
    }
}
