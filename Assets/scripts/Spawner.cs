using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Attacker[] Attackers;
    private Spawner[] spawners;
    private int numberOfSpawners;
    private bool isSpawning = false;
    private GameObject parentObject;

    private void Start() {
        parentObject = GameObject.Find(Constants.ATTACKER_PARENT_OBJ);
        if (parentObject == null) {
            parentObject = new GameObject(Constants.ATTACKER_PARENT_OBJ);
        }
        spawners = GameObject.FindObjectsOfType<Spawner>();
        numberOfSpawners = spawners.Length;
    }

    private void Update() {
        foreach (Attacker attacker in Attackers) {
            if (!isSpawning) {
                isSpawning = true;
                StartCoroutine(SpawnNPC(attacker));
            }
        }
    }

    private IEnumerator SpawnNPC(Attacker attacker) {
        float spawnDelay = attacker.spawnFrequency;
        float spawnRate = (1 / spawnDelay) * Time.deltaTime; // Spawn rate per second

        yield return new WaitForSeconds(spawnDelay);

        attacker = Instantiate(attacker);
        attacker.transform.parent = parentObject.transform;
        attacker.transform.position = gameObject.transform.position;
        isSpawning = false;
    }
}
