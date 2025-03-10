using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public PlayerStats stats;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    private void Start() {
        //stats = GetComponent<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    void Update() {
        playerCollector.radius = stats.GetCurrentMagnet();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null) {

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 forceDir = (transform.position - collision.transform.position).normalized;
            rb.AddForce(forceDir * pullSpeed);

            //collectible.Collect();
        }

    }
}
