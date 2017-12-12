using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] NPCs;
    private Spawner[] spawners;
    private int numberOfSpawners;
    private bool isSpawning = false;

    private void Start() {
        spawners = GameObject.FindObjectsOfType<Spawner>();
        numberOfSpawners = spawners.Length;
    }

    private void Update() {
        foreach (GameObject npc in NPCs) {
            if (!isSpawning) {
                isSpawning = true;
                StartCoroutine(SpawnNPC(npc));
            }
        }
    }

    private IEnumerator SpawnNPC(GameObject npc) {
        GameObject parentObject = GameObject.Find("Attackers");

        float spawnDelay = parentObject.spawnFrequency;
        float spawnRate = (1 / spawnDelay) * Time.deltaTime; // Spawn rate per second

        yield return new WaitForSeconds(spawnDelay);

        npc = Instantiate(npc) as GameObject;
        npc.transform.parent = parentObject.transform;
        npc.transform.position = gameObject.transform.position;
        isSpawning = false;
    }
}
