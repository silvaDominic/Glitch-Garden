using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Attacker[] attackers;
    private Spawner[] spawners;
    private int numberOfSpawners;
    private bool isSpawning = false;
    private GameObject parentObject;
    [Range(0, 1f)]
    public float staggerAmount = Constants.DEFAULT_STAGGER_AMOUNT;

    private void Start() {
        parentObject = gameObject;

        spawners = GameObject.FindObjectsOfType<Spawner>();
        numberOfSpawners = spawners.Length;
    }

    private void Update() {
        int attackerIndex = Random.Range(0, attackers.Length);
        Attacker attacker = attackers[attackerIndex];
        if (!isSpawning) {
            isSpawning = true;
            Debug.Log("Spawning attacker: " + attacker.name);
            StartCoroutine(SpawnNPC(attacker));
        }
    }

    // METHOD IMPERFECT
    // Spawns Attackers at specified intervals
    // What's unique about this method is it's use of a stagger variable that is compared to a preset mean spawn freuqnecy in order to produce a more random flow of NPCS.
    // The stagger amount (a float number between 0 and 1) is multiplied by the mean spawn frequency to produce an offset.
    // This offset is SUBTRACTED from the mean spawn frequency to yeild the current spawn time for that NPC
    // It is further multipled by the number of spawners to produce a broader frequency for the whole play space (opposed to per lane)

    private IEnumerator SpawnNPC(Attacker attacker) {
        float meanSpawnFrequency = attacker.meanSpawnFreuqency ; // Time before each spawn, Ex: Every 3 seconds
        float spawnOffset = Random.Range(0, staggerAmount * meanSpawnFrequency) * numberOfSpawners; // If stagger is 0, uniform spawn pattern; if stagger is 1, most random spawn pattern

        yield return new WaitForSeconds(Mathf.Abs(meanSpawnFrequency - spawnOffset)); // Absolute value is used to prevent negative numbers from yeilding instant spawns
        attacker = Instantiate(attacker);
        attacker.transform.parent = parentObject.transform;
        attacker.transform.position = gameObject.transform.position;

        isSpawning = false;
    }
}
