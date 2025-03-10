using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpGem : Pickup, ICollectible
{
    public int experienceValue;

    public void Collect() {
        Debug.Log("Collect");
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExp(experienceValue);
    }

}
