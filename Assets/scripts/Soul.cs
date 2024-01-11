using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    private CircleCollider2D CircleCollider2D;

    private float speed = 2.0f;
    private bool ChaseTrigger = false;

    void Start()
    {
        CircleCollider2D = GetComponent<CircleCollider2D>();
        upgradeManager = GameObject.FindObjectOfType<UpgradeManager>();
        SetPickupDistance(Game.Instance.CurrentSoulRange);
    }
    // Update is called once per frame
    void Update()
    {

        if (ChaseTrigger)
        {
            transform.up = Game.Instance.SpawnedPlayer.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, Game.Instance.SpawnedPlayer.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Game.Instance.SpawnedPlayer.transform.position) < 0.1f)
            {
                Destroy(this.gameObject);
                ChaseTrigger = false;
                upgradeManager.addSouls(1);
            }
            speed += 0.1f;

        }
    }
    public void SetPickupDistance(float dist)
    {
        CircleCollider2D.radius = dist;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("triggered");
        if (other == Game.Instance.SpawnedPlayer.GetComponent<Collider2D>())
        {
            print("triggered");
            ChaseTrigger = true;
        }
    }
}
