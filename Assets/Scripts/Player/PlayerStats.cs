using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    CharacterSO characterData;

    //Current values
    private float _currentHealth;
    private float _currentMoveSpeed;
    private float _currentMight;
    private float _currentRecovery;
    private float _currentProjectileSpeed;
    private float _currentMagnet;


    //current weapons
    public List<GameObject> spawnedWeapons;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }


    public List<LevelRange> levelRanges;

    //I-frames
    [Header("I-Frames")]
    public float invulDuration;
    float invulTimer;
    bool isInvuln;

    // Start is called before the first frame update
    void Awake() {
        //pull data from character select menu
        characterData = CharacterSelect.GetData();
        // we got our data, now destroy
        CharacterSelect.instance.DestroySingleton();

        _currentHealth = characterData.MaxHealth;
        _currentMoveSpeed = characterData.MoveSpeed;
        _currentMight = characterData.Might;
        _currentRecovery = characterData.Recovery;
        _currentProjectileSpeed = characterData.ProjectileSpeed;
        _currentMagnet = characterData.Magnet;

        SpawnWeapon(characterData.StartingWeapon);
    }

    private void Start() {
        //init
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExp(int amount) {
        experience += amount;
    }

    void Update() {
        InvulnCheck();
        Recover();
    }

    private void InvulnCheck() {
        if (invulTimer > 0) {
            invulTimer -= Time.deltaTime;
            if (invulTimer <= 0) {
                isInvuln = false;
            }
        }
    }

    public void TakeDamage(float amount) {
        if (isInvuln) { return; }
        _currentHealth -= amount;
        
        // Player got hit, set invuln now
        invulTimer = invulDuration;
        isInvuln = true;

        if(_currentHealth <= 0) {
            Kill();
        }
    }

    public void RestoreHealth(float amount) {
        if(_currentHealth < characterData.MaxHealth) {
            _currentHealth += amount;
            if (_currentHealth > characterData.MaxHealth) {
                _currentHealth = characterData.MaxHealth;
            }
    }
        }
    public void Kill() {
        Debug.Log("Player died");
    }

    void LevelUpCheck() {
        if (experience >= experienceCap) {
            level++;
            experience -= experienceCap;

            int expCapIncrease = 0;
            foreach (LevelRange range in levelRanges) {
                if (level >= range.startLevel && level <= range.endLevel) {
                    expCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += expCapIncrease;
        }

    }

    private void Recover() {
        if (_currentHealth < characterData.MaxHealth) {
            _currentHealth += _currentRecovery * Time.deltaTime;
            if (_currentHealth > characterData.MaxHealth) {
                _currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon) {
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.parent = transform;
        spawnedWeapons.Add(spawnedWeapon);
    }
    public float GetCurrentHealth() { return _currentHealth; }
    public float GetCurrentMight() { return _currentMight; }
    public void SetCurrentMight(float newMight) { _currentMight = newMight; }

    public float GetCurrentMoveSpeed() { return _currentMoveSpeed; }
    public void SetCurrentMoveSpeed(float newMoveSpeed) { _currentMoveSpeed = newMoveSpeed; }

    public float GetCurrentProjectileSpeed() { return _currentProjectileSpeed; }
    public float GetCurrentMagnet() { return _currentMagnet; }


}
