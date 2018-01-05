using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : Npc {

    [Tooltip("The rate at which an enemy will spawn")]
    public float meanSpawnFreuqency;

    private void Start() {
        base.Start();
    }

    // *Not sure if overriding is the best solution here
    protected override void DestroyNPC(GameObject gameObject) {
        // --- Optionally trigger a death animation here ---

        // Removes gameobject position from available grid spaces
        Debug.Log("----- Destroying " + gameObject.name + " and removing from grid at " + gameObject.transform.position);
        RemoveDefenderFromGrid(gameObject);
        Destroy(gameObject);
    }

    private void RemoveDefenderFromGrid(GameObject defender) {
        DefenderManager defenderManager = GameObject.FindObjectOfType<DefenderManager>();
        Vector2 defenderPos = defender.transform.position;
        defenderManager.RemoveElementFromGrid(defenderPos.ToString());
    }
}
