using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public float speed;
    public float damage;
    public Transform PlayerTransform;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
        Vector3 displacement = PlayerTransform.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(PlayerTransform.position, transform.position) > 0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
    }
}
