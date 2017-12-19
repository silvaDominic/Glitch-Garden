using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMan : Attacker {

    // Use this for initialization
    void Start() {
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " collides with " + collision);

        GameObject currentTarget = collision.gameObject;

        // Ignore collision logic if same NPC type
        if (currentTarget.tag == Constants.ATTACKER || currentTarget.tag == Constants.PROJECTILE) {
            return;
        } else if (currentTarget.GetComponent<GraveStone>()) {
            GetAnimator().SetTrigger(Constants.JUMP);
        } else {
            GetAnimator().SetBool(Constants.ATTACK, true);
            Attack(currentTarget);
        }
    }
}
