using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats playerStats;
    public PassiveItemSO passiveItemData;

    protected virtual void ApplyModifier() {
        //apply boost

    }
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }

    void Update()
    {
        
    }
}
