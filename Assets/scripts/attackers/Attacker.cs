using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : Npc {

    [Tooltip("The rate at which an enemy will spawn")]
    public float meanSpawnFreuqency;
}
