using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Health health;
    private GameObject currentTarget;
    public float projectileSpeed, damage, rotationSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        currentTarget = collision.gameObject;
        Debug.Log(gameObject.name + " collided with " + collision.name);
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
