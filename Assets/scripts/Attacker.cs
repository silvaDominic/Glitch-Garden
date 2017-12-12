using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [Tooltip("The rate at which an enemy will spawn")]
    public float spawnFrequency;

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

    public void SetSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject obj) {
        currentTarget = obj;
    }

    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }
    }
}
