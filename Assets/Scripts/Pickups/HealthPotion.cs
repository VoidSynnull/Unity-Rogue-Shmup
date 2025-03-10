using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectible {
    public float healthValue;

    public void Collect() {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthValue);
        Destroy(gameObject);

    }
}
