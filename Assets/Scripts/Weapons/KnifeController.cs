using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController

{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab, transform.position, Quaternion.identity);
        spawnedKnife.GetComponent<KnifeBehavior>().DirectionChecker(playerMovement.lastMoveDir);
        //Rigidbody2D rb = spawnedKnife.GetComponent<Rigidbody2D>();
        //rb.velocity = playerMovement.lastMoveDir  * speed; // Move in last move direction

        // Rotate the knife to face its movement direction
        //float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        //spawnedKnife.transform.rotation = Quaternion.Euler(0, 0, angle);
        //spawnedKnife.GetComponent<KnifeBehavior>().DirectionChecker(playerMovement.moveDir);
    }
}
