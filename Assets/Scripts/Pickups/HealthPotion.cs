using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible {
    public float healthValue;

    public void Collect() {
        Debug.Log("Collect");
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthValue);

    }
}
