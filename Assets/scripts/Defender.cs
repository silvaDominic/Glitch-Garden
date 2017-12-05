using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public Projectile projectile;
    private Health health;
    private GameObject currentTarget;
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if (!currentTarget) {
            if (anim.parameterCount > 0) {
                anim.SetBool("isAttacking", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " triggered" + " with " + collision);
        currentTarget = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("On exit, " + collision.name);
        currentTarget = null;
    }

    public void StrikeCurrentTarget(float damage) {
        Debug.Log(name + " delivered " + damage + " damage.");
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack() {
        if (projectile) {
            LaunchProjectile();
        } else {
            Debug.Log("No projectile attached to Component");
        }
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

    public void LaunchProjectile() {
        Debug.Log("Fired " + projectile.name);
        Vector3 startingPosition = gameObject.transform.position + new Vector3(0.5f, 0, 0);
        Projectile fired_projectile = Instantiate(projectile, startingPosition, Quaternion.identity);
        fired_projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(projectile.projectileSpeed, 0, 0);
    }
}
