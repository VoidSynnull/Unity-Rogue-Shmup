using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinach : PassiveItem {
    protected override void ApplyModifier() {
        playerStats.SetCurrentMight(playerStats.GetCurrentMight() * (1 + passiveItemData.Multiplier / 100f));
    }

}

