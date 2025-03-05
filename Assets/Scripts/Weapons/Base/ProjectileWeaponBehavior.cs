using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    public WeaponSO weaponData;
    public Vector3 direction;
    //public float lifeTime;
    public float angleOffset = 0f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, weaponData.lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DirectionChecker(Vector3 dir) {
        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 roation = transform.localRotation.eulerAngles;

        if(dirX < 0 && dirY == 0) {
            //scale.x *= -1;
            //scale.y *= -1;
        }
        float angle = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;

        //transform.localScale = scale;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }



}
