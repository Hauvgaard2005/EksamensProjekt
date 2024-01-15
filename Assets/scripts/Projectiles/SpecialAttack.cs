using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    private Vector2 mousePos;
    private Rigidbody2D rb;

    public float speed = 10f;
    public float range = 5f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (mousePos - (Vector2)transform.position).normalized * speed;

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
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }

    }
}
