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

    public float despawnDistance = 20f;
    Transform player;


    private void Start() {
        player = FindObjectOfType<PlayerStats>().transform;
    }
    private void Update() {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }
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
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) { 
        PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
        if (playerStats != null) {
            playerStats.TakeDamage(enemyData.AttackValue);
        }
    }
    }

    public void ReturnEnemy() {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + enemySpawner.spawnPositions[Random.Range(0, enemySpawner.spawnPositions.Count)].position;
    }
    private void OnDestroy() {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
       enemySpawner.GetComponent<EnemySpawner>().OnEnemyDeath();
    }
    public float GetCurrentHealth() { return _currentHealth; }
    public float GetCurrentMoveSpeed() { return _currentMoveSpeed; }

}
