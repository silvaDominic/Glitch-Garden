using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {

    public const string JUMP = "triggerJump";
    public const string ATTACK = "isAttacking";
    public const string ATTACKER = "Attacker";
    public const string DEFENDER = "Defender";
    public const string PROJECTILE = "Projectile";
    public const string ATTACKER_PARENT_OBJ = "Spawner";
    public const string DEFENDER_PARENT_OBJ = "Defenders";
    public const string PROJECTILE_PARENT_OBJ = "Projectiles";
    public const string SPAWNER_PARENT_OBJ = "SpawnerS";

    public const string LOSE_SCREEN = "03b-lose";
    public const string WIN_SCREEN = "03a-win";
    public const string LEVEL_1 = "02-level_01";
    public const string LEVEL_2 = "02-level_02";
    public const string LEVEL_3 = "02-level_03";

    public const int DEFALT_STAR_COUNT = 100;
    public const float DEFAULT_STAGGER_AMOUNT = 0.75f;
}
