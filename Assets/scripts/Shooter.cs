using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    private GameObject projectilesParent;
    public Projectile projectile;
    public GameObject gun;

	// Use this for initialization
	void Start () {
        projectilesParent = GameObject.Find("Projectiles");
        if (projectilesParent == null) {
            projectilesParent = new GameObject("Projectiles");
        }
	}

    private void LaunchProjectile() {
        Projectile fired_projectile = Instantiate(projectile);
        fired_projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(projectile.projectileSpeed, 0, 0);
        fired_projectile.transform.parent = projectilesParent.transform;
        fired_projectile.transform.position = gun.transform.position;
        Debug.Log(gun.transform.position);
        Debug.Log("Projectile fired from: " + gameObject.name + " at position " + fired_projectile.transform.position);
    }
}