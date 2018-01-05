using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    private GameObject projectilesParent;
    public Projectile projectile;
    public GameObject gun;
    private Animator anim;
    private Spawner thisSpawner;
    public int shooterReach = 2;

	// Use this for initialization
	private void Start () {
        anim = GameObject.FindObjectOfType<Animator>();

        projectilesParent = GameObject.Find(Constants.PROJECTILE_PARENT_OBJ);
        if (projectilesParent == null) {
            projectilesParent = new GameObject(Constants.PROJECTILE_PARENT_OBJ);
        }

        SetMyLaneSpawner();
        Debug.Log("This spawner: " + thisSpawner.transform.position);
    }

    private void Update() {
        if (IsAttackerAheadInLane()) {
            Debug.Log("Attacking!");
            anim.SetBool(Constants.ATTACK, true);
        } else {
            anim.SetBool(Constants.ATTACK, false);
        }
    }

    private bool IsAttackerAheadInLane() {
        if (thisSpawner.transform.childCount <= 0) {
            return false;
        }

        foreach (Transform attackers in thisSpawner.transform) {
            float attackerPosition = attackers.transform.position.x;
            float shooterRange = gameObject.transform.position.x + shooterReach;
            Debug.Log("Shooter range: " + shooterRange);
            if (attackerPosition <= shooterRange) {
                Debug.Log("In range");
                return true;
            }
        }
        return false;
    }

    private void SetMyLaneSpawner() {
        Spawner[]  spawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
            if (spawner.transform.position.y == gameObject.transform.position.y) {
                thisSpawner = spawner;
                Debug.Log("Spawner: " + spawner.transform.position.y + ", This GameObject: " + gameObject.transform.position.y);
                return;
            }
        }
        Debug.LogError("No spawner associated with current NPC");
    }

    private void LaunchProjectile() {
        Projectile fired_projectile = Instantiate(projectile) as Projectile;
        fired_projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(projectile.projectileSpeed, 0, 0);
        fired_projectile.transform.parent = projectilesParent.transform;
        fired_projectile.transform.position = gun.transform.position;
    }
}