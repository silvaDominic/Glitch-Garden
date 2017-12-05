using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Defender))]
[RequireComponent(typeof(Rigidbody2D))]
public class GraveStone : MonoBehaviour {

    Animator anim;
    Defender defender;

    // Use this for initialization
    void Start() {
        anim = gameObject.GetComponent<Animator>();
        defender = gameObject.GetComponent<Defender>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " collides with " + collision);

        GameObject currentTarget = collision.gameObject;

        // Ignore collision logic if NOT an Attacker
        if (!currentTarget.GetComponent<Attacker>()) {
            return;
        } else {
            anim.SetBool("isAttacking", true);
            defender.Attack(currentTarget);
        }
    }
}
