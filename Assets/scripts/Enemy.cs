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
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
