using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

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

    // Figure out why Attack works for receiving currentTarget but OnTriggerEnter2D doesn't
    //private void OnTriggerEnter2D(Collider2D collision) {
    //    Debug.Log(name + " triggered" + " with " + collision);
    //    currentTarget = collision.gameObject;
    //}

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

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }
}
