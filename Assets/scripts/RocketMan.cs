using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Rigidbody2D))]
public class RocketMan : MonoBehaviour {

    Animator anim;
    Attacker attacker;

    // Use this for initialization
    void Start() {
        anim = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " collides with " + collision);

        GameObject obj = collision.gameObject;

        // Ignore collision logic if NOT a defender
        if (!obj.GetComponent<Defender>()) {
            return;
        } else if (obj.GetComponent<GraveStone>()) {
            anim.SetTrigger("triggerJump");
        } else {
            anim.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
