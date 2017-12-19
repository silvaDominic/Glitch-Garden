using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;
    private SpawnDefender spawner;

    private void Start() {
        spawner = GameObject.FindObjectOfType<SpawnDefender>();
    }

    public void DealDamage(float damage) {
        health -= damage;

        if (health <= 0) {
            DestroyObject();
        }
    }

    private void DestroyObject() {
        // Optionally trigger a death animation here

        // Removes gameobject position from available grid spaces
        Debug.Log("Destroying " + gameObject.name + " and removing from grid at " + gameObject.transform.position);
        Vector2 gameObjectPos = gameObject.transform.position;
        spawner.RemoveElementFromGrid(gameObjectPos.ToString());
        Destroy(gameObject);
    }
}
