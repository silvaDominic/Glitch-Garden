using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed;
    private GameObject currentTarget;
    private Health health;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            anim.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " triggered" + " with " + collision);
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
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
