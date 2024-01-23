using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Numerics;

public class Player : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public float speed = 3.0f;
    private bool isTakingDamage = false;
    public Projectile projectilePrefab;
    public SpecialAttack specialAttackPrefab;
    [SerializeField] private Enemy Enemy;
    private bool _invincible = false;

    public Collider2D TerrainCollider = FindObjectOfType<EdgeCollider2D>();
    public Rigidbody2D rb;

    public PlayerUi playerUi;

    

    [Header("Dash Variables")]
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashCooldown;

    //current stamina... use for UI?
    [SerializeField] private float stamina = 3f;
    bool isDashing;
    UnityEngine.Vector2 moveDir;


    //Projectile upgrades

    [Header("Projectile Upgrades")]
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
        playerUi.SetHealth(currentHealth);
        rb = GetComponent<Rigidbody2D>();
        //upgradeManager = GameObject.FindObjectOfType<HellUpgrader>();


    }


    // Update is called once per frame
    void Update()
    {
        //midlertidig manuel damage
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10f);
        }

        if (isDashing)
        {
            return;
        }

        //get cur move direction
        moveDir = new UnityEngine.Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        timer += Time.deltaTime;
        stamina += Time.deltaTime;

        //movement
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

        //dash

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (stamina >= dashCooldown)
            {
                StartCoroutine(Dash(moveDir));
                stamina = 0.0f;
            }
        }

        //health
        if (currentHealth <= 0f)
        {
            Destroy(this.gameObject);
        }

        //shooting
        if (timer >= reloadSpeed)
        {
            SpawnProjectile();
            timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) //&& upgradeManager.curSoul >= specialAttackPrefab.cost)
        {
            SpecialAttack();
        }



        //stops when colliding with tag water collider
        if (TerrainCollider.IsTouching(GetComponent<Collider2D>()) == true)
        {
            speed = 0f;
        }
    }

    //methods
    private void MoveForward()
    {
        transform.Translate(UnityEngine.Vector2.up * Time.deltaTime * speed);
    }

    private void MoveBackward()
    {
        transform.Translate(UnityEngine.Vector2.down * Time.deltaTime * speed);
    }

    private void MoveLeft()
    {
        transform.Translate(UnityEngine.Vector2.left * Time.deltaTime * speed);
    }

    private void MoveRight()
    {
        transform.Translate(UnityEngine.Vector2.right * Time.deltaTime * speed);
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;

    }
    private void SpecialAttack()
    {
        SpecialAttack specialAttack = Instantiate(specialAttackPrefab);
        specialAttack.transform.position = transform.position;
    }

    private IEnumerator Dash(UnityEngine.Vector2 moveDir)
    {
        isDashing = true;
        Game.Instance.SpawnedPlayer.rb.AddForce(moveDir * dashSpeed, ForceMode2D.Impulse);
        //set added force back to zero
        yield return new WaitForSeconds(dashTime);
        Game.Instance.SpawnedPlayer.rb.velocity = UnityEngine.Vector2.zero;
        isDashing = false;
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
            UnityEngine.Vector2 force = transform.position - other.transform.position;
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

            playerUi.SetHealth(currentHealth);
            StartCoroutine(InvincibilityFrames());
            playerUi.UpdateHealthUI();
            playerUi.lerpTimer = 0f;
        }

    }

    private IEnumerator InvincibilityFrames()
    {
        _invincible = true;
        yield return new WaitForSeconds(1f);
        _invincible = false;
    }
}
