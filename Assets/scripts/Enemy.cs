using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        private float HP;
        private float speed;
        public float damage;
        //er public transform ligemeget?
        //public transform target;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
        vector3 displacement = Player.position -transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance (Player.position, transform.position) > 0f) {
            transform.position += (displacement * speed * Time.deltaTime);
                        
        }
    }
}
