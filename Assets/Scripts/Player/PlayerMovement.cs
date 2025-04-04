using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 moveDir { get; private set; }
    public Vector2 lastMoveDir { get; private set; } = new Vector2(1, 0);

    PlayerStats playerStats;

    public static Transform PlayerTransform { get; private set; }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        playerStats = GetComponent<PlayerStats>();
        PlayerTransform = transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (moveDir != Vector2.zero) {
            lastMoveDir = moveDir;
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDir.x * playerStats.GetCurrentMoveSpeed(), moveDir.y * playerStats.GetCurrentMoveSpeed());
    }
    public void Move(InputAction.CallbackContext context) {
        moveDir = context.ReadValue<Vector2>().normalized;
        
    }
}
