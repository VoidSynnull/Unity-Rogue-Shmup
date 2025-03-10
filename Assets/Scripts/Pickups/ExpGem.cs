using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpGem : MonoBehaviour, ICollectible
{
    public int experienceValue;

    public void Collect() {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExp(experienceValue);
        Destroy(gameObject);

    }

}
