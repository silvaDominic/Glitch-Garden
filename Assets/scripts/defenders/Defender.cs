using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Defender : Npc {
    private DefenderManager defenderManager;
    public int cost;

    private void Start() {
        
    }

    // *Not sure if overriding is the best solution here
    public override void DestroyNPC(GameObject gameObject) {
        // --- Optionally trigger a death animation here ---

        // Removes gameobject position from available grid spaces
        Debug.Log("Destroying " + gameObject.name + " and removing from grid at " + gameObject.transform.position);
        RemoveDefenderFromGrid();
        Destroy(gameObject);
    }

    private void RemoveDefenderFromGrid() {
        defenderManager = GameObject.FindObjectOfType<DefenderManager>();
        Vector2 gameObjectPos = gameObject.transform.position;
        defenderManager.RemoveElementFromGrid(gameObjectPos.ToString());
    }
}
