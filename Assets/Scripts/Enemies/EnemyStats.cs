using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemySO enemyData;

    //Current values
    private float _currentHealth;
    private float _currentMoveSpeed;
    private float _currentAttackValue;
    // Start is called before the first frame update
    void Awake()
    {
        _currentHealth = enemyData.MaxHealth;
        _currentMoveSpeed = enemyData.MoveSpeed;
        _currentAttackValue = enemyData.AttackValue;
    }

    public void TakeDamage(float damage) {
        _currentHealth -= damage;
        if (_currentHealth <= 0) {
            Kill();
        }

    }
    public void Kill() {
        Destroy(gameObject);
    }


}
