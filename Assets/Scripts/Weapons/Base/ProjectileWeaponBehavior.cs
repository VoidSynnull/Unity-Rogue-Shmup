using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponSO weaponData;
    public Vector3 direction;
    public float angleOffset = 0f;


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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DirectionChecker(Vector3 dir) {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 roation = transform.localRotation.eulerAngles;

        if(dirX < 0 && dirY == 0) {
            //scale.x *= -1;
            //scale.y *= -1;
        }
        float angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;

        //transform.localScale = scale;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy")) {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    void ReducePierce() {
        currentPierce -= 1;
        if (currentPierce <= 0) {
            Destroy(gameObject);
        }
    }


}
