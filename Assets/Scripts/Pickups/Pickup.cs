using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ICollectible collectible;
    private void Start() {
        collectible = GetComponent<ICollectible>();
    }
    private  void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collectible.Collect();
            Destroy(gameObject);
        }
    }
}
