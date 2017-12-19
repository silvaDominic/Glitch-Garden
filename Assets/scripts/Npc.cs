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

    public void Update() {
        if (currentSpeed != 0) {
            gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
        //if (currentTarget != null) {
        //    if (anim.parameterCount > 0) {
        //        anim.SetBool(Constants.ATTACK, false);
        //    }
        //}

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
        Debug.Log(name + " delivered " + damage + " damage to " + currentTarget.name);
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

    public GameObject GetCurrentTarget() {
        return currentTarget;
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    public float GetCurrentSpeed() {
        return currentSpeed;
    }

    public Animator GetAnimator() {
        return anim;
    }
}
