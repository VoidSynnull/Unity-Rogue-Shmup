using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PassiveItemSO", menuName ="SO/PassiveItem")]
public class PassiveItemSO : ScriptableObject {
    public float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }


}
