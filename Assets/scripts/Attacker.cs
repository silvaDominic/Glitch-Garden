using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed;
    private GameObject currentTarget;
    private Health health;
    private Animator anim;
    private int index;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        index = 0;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            if (anim.parameterCount > 0) {
                anim.SetBool("isAttacking", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + " triggered" + " with " + collision);
    }

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

    public void StrikeCurrentTarget(float damage) {
        Debug.Log(gameObject.name + " delivered " + damage + " damage.");
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }
}
