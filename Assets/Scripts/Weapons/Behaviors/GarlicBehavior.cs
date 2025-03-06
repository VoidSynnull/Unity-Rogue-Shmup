using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehavior : MeleeWeaponBehavior
{
    List<GameObject> hitEnemies;
    // Start is called before the first frame update
    protected override void Start()
    {
        hitEnemies = new List<GameObject>();
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy") && !hitEnemies.Contains(collision.gameObject)) {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(currentDamage);
            hitEnemies.Add(collision.gameObject);
            Debug.Log(hitEnemies.Count);
        }
        //base.OnTriggerEnter2D(collision);
    }
}
