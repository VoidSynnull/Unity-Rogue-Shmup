using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehavior : MonoBehaviour
{
    public WeaponSO weaponData;
    // Start is called before the first frame update
    protected virtual void Start()
    {
     Destroy(gameObject, weaponData.lifeTime);   
    }


}
