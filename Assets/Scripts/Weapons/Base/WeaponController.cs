using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponSO weaponData;
    float currentCooldown;


    protected PlayerMovement playerMovement;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0) {
            Attack();
        }
    }

    protected virtual void Attack() {
        currentCooldown = weaponData.cooldownDuration;
    }
}
