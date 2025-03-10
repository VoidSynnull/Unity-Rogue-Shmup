using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehavior : MonoBehaviour
{
    public WeaponSO weaponData;
    //current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected int currentPierce;
    protected float currentCooldownDuration;

    private void Awake() {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentPierce = weaponData.Pierce;
        currentCooldownDuration = weaponData.CooldownDuration;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
     Destroy(gameObject, weaponData.LifeTime);   
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(currentDamage);
        }
        else if (collision.CompareTag("Prop")) {
            BreakableProps breakableProp = collision.GetComponent<BreakableProps>();
            breakableProp.TakeDamage(currentDamage);
        }
    }


}
