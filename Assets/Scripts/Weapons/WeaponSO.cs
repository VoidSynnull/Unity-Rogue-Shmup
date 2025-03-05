using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/Weapon")]
public class WeaponSO : ScriptableObject
{
    public GameObject prefab;
    //stats
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;
    public float lifeTime;

}
