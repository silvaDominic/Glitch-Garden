using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Health health;
    private GameObject currentTarget;
    public float projectileSpeed, damage;
    private ProjectileSoundController soundController;


    // Use this for initialization
    void Start () {
        Debug.Log("NAME: " + gameObject.name);
        soundController = gameObject.GetComponent<ProjectileSoundController>();
        soundController.PlaySound(Constants.SHOT_SOUND);
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        currentTarget = collision.gameObject;
        Debug.Log("Projectile collides with " + currentTarget.name);
        if (currentTarget) {
            health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
                if (health.GetHealth() <= 0) {
                    // Destroys target
                    Destroy(currentTarget);
                }
            }
        }
        // Destroys projectile
        soundController.PlaySound(Constants.IMPACT_SOUND);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<Renderer>().enabled = false;
        Invoke("DestroyProjectile", soundController.GetAudioSource().clip.length);
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
