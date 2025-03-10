using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterSO characterData;

    //Current values
    private float _currentHealth;
    private float _currentMoveSpeed;
    private float _currentMight;
    private float _currentRecovery;
    private float _currentProjectileSpeed;

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
        _currentHealth = characterData.MaxHealth;
        _currentMoveSpeed = characterData.MoveSpeed;
        _currentMight = characterData.Might;
        _currentRecovery = characterData.Recovery;
        _currentProjectileSpeed = characterData.ProjectileSpeed;
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
        if (_currentHealth < characterData.MaxHealth) {
            _currentHealth += amount;
            if (_currentHealth < characterData.MaxHealth) {
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

}
