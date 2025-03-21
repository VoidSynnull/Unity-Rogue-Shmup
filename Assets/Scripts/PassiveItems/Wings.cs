using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : PassiveItem
{
    protected override void ApplyModifier() {
        playerStats.SetCurrentMoveSpeed(playerStats.GetCurrentMoveSpeed() * ( 1 + passiveItemData.Multiplier / 100f));
    }

}
