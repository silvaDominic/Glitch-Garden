using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;

    public void DealDamage(float damage) {
        health -= damage;

        if (health <= 0) {
            // Optionally trigger a death animation here
            DestroyObject();
        }
    }

    private void DestroyObject() {
        Destroy(gameObject);
    }
}
