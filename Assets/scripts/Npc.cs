using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour {

    private Health health;
    private GameObject currentTarget;
    private float currentSpeed;
    private Animator anim;

    public void Start() {
        anim = GetComponent<Animator>();
    }

    public virtual void Update() {
        if (currentSpeed != 0) {
            gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }

        if (currentTarget == null) {
            anim.SetBool(Constants.ATTACK, false);
        }
    }

    // Figure out why Attack works for receiving currentTarget but OnTriggerEnter2D doesn't
    //private void OnTriggerEnter2D(Collider2D collision) {
    //    Debug.Log(name + " triggered" + " with " + collision);
    //    currentTarget = collision.gameObject;
    //}

    // Delivers phyical damage to target
    // Called from Animation Clip
    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
                if (health.GetHealth() <= 0) {
                    DestroyNPC(currentTarget);
                }
            }
        }
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

    public Animator GetAnimator() {
        return anim;
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    protected virtual void DestroyNPC(GameObject gameObject) {
        // --- Optionally trigger a death animation here ---

        // Removes gameobject position from available grid spaces
        Debug.Log("Destroying " + gameObject.name);
        Destroy(gameObject);
    }
}
