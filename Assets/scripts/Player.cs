using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public float speed = 3.0f;
    public int gold = 0;
    int level = 1;
    public Projectile projectilePrefab;
    [SerializeField] private Enemy Enemy;


    public Healthbar healthbar;

    //Projectile upgrades
    public float damage;
    public float Range;
    public float reloadSpeed;

    float timer = 0.0f;






    // Start is called before the first frame update
    private void Start()
    {
        damage = 5f;
        Range = 5f;
        reloadSpeed = 2f;
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);


    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthbar.SetHealth(currentHealth);
    }


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;


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

        if (Game.Instance.SpawnedPlayer.GetComponent<Collider2D>().IsTouching(Game.Instance.spawnedEnemy.GetComponent<Collider2D>()))
        {
            Collison();
        }

        if (currentHealth <= 0f)
        {
            Destroy(this.gameObject);
        }

        if (timer >= reloadSpeed)
        {
            SpawnProjectile();
            timer = 0.0f;
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



    private void Collison()
    {
        currentHealth -= 10f;
    }




}
