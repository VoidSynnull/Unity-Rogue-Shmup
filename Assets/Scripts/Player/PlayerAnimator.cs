using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moveDir.x != 0 || playerMovement.moveDir.y != 0) {
            animator.SetBool("Move", true);
        } else {
            animator.SetBool("Move", false);
        }

        SpriteDirectionCheck();
    }

    void SpriteDirectionCheck() {
        //spriteRenderer.flipX = playerMovement.moveDir.x < 0 ? true : false;
        if(playerMovement.moveDir.x < 0) {
            spriteRenderer.flipX = true;
        } else if(playerMovement.moveDir.x > 0) {
            spriteRenderer.flipX = false;
        }
    }
}
