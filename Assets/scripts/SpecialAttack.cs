using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    private Vector2 mousePos;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (mousePos - (Vector2)transform.position).normalized * 10f;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == Game.Instance.NearestEnemy.GetComponent<Collider2D>())
        {
            Destroy(gameObject);
        }
    }
}
