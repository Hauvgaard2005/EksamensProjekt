using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private HellUpgrader upgradeManager;

    public float speed = 10f;
    public float range = 5f;
    private float timer = 0f;

    public int cost = 1;

    [Header("AOE")]
    public float SplashRange = 1f;
    public float SplashDamage = 15f;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (mousePos - (Vector2)transform.position).normalized * speed;
        upgradeManager = GameObject.FindObjectOfType<HellUpgrader>();
        upgradeManager.removeSouls(cost);
        transform.up = mousePos - (Vector2)transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= range)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SplashRange > 0)
        {
            var enemiesHit = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var enemy in enemiesHit)
            {
                if (enemy.GetComponent<Enemy>() != null)
                {
                    enemy.GetComponent<Enemy>().HP -= SplashDamage;
                }
            }
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }


    }
}
