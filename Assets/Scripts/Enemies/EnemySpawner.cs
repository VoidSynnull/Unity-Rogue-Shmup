using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave {
        public string waveName;
        public List<EnemyGroup> enemyGroup;
        public int waveQuota; // num enemies to spawn this wave
        public float spawnInterval;
        public float spawnCount; // number already spawned this wave
    }
    [System.Serializable]
    public class EnemyGroup {
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
        public GameObject enemyPrefab;
    }

    [Header("Spawner Settings")]
    public float waveInterval; //time between waves
    public int maxEnemiesAllowed; //at one time
    int numEnemiesAlive;
    public bool maxEnemiesReached = false;
    float spawnTimer;

    [Header("Spawner Positions")]
    public List<Transform> spawnPositions;

    public List<Wave> waves; // all our waves
    public int CurrentWaveCount = 0;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        CalcWaveQuota();
    }

    IEnumerator BeginNextWave() {
        yield return new WaitForSeconds(waveInterval);
        if(CurrentWaveCount < waves.Count - 1) {
            //start next wave
            CurrentWaveCount++;
            CalcWaveQuota();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if wave has ended and there are no more enemies to spawn
        if (CurrentWaveCount < waves.Count && waves[CurrentWaveCount].spawnCount == 0) {
            StartCoroutine(BeginNextWave());
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[CurrentWaveCount].spawnInterval) {
            spawnTimer = 0;
            SpawnEnemies();
        }

    }

    void CalcWaveQuota() {
        int currentWaveQuota = 0;
        foreach(EnemyGroup enemyGroup in waves[CurrentWaveCount].enemyGroup) {
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[CurrentWaveCount].waveQuota = currentWaveQuota;
    }

    public void SpawnEnemies() {
        //if the current wave still has enemies to spawn
        if (waves[CurrentWaveCount].spawnCount < waves[CurrentWaveCount].waveQuota && !maxEnemiesReached) {
            foreach (EnemyGroup enemyGroup in waves[CurrentWaveCount].enemyGroup) {
                //if there are less spawned then the max number specified in the enemy group
                if(enemyGroup.spawnCount < enemyGroup.enemyCount) {
                    if(numEnemiesAlive >= maxEnemiesAllowed) {
                        maxEnemiesReached = true;
                        return;
                    }
                    //spawn
                    Vector3 spawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
                    Instantiate(enemyGroup.enemyPrefab, player.transform.position + spawnPos, Quaternion.identity);

                    //increment counters
                    enemyGroup.spawnCount++;
                    waves[CurrentWaveCount].spawnCount++;
                    numEnemiesAlive++;

                }
            }
        }

        //reset flag
        if(numEnemiesAlive < maxEnemiesAllowed) {
            maxEnemiesReached = false;
        }
    }

    public void OnEnemyDeath() {
        numEnemiesAlive--;

    }
}
