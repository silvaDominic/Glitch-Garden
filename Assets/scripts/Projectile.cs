using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed, damage, rotationSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
        //MoveProjectile();
	}

    public void MoveProjectile() {
        Vector3 startingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        Instantiate(gameObject, startingPosition * projectileSpeed * Time.deltaTime, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(gameObject.name + " collided with " + collision.name);
    }
}
