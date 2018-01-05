using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSoundController : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] soundArray;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("AUIDO SOURCE " + audioSource);
    }

    // Use this for initialization
    void Start () {

	}
	
    public void PlaySound(int soundIndex) {
        audioSource.PlayOneShot(soundArray[soundIndex]);
        
    }

    public AudioSource GetAudioSource() {
        return audioSource;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
