using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;

    public void DealDamage(float damage) {
        health -= damage;
    }

    public float GetHealth() {
        return health;
    }

    public void SetHealth(float newHealth) {
        health = newHealth;
    }
}
