using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSoundController : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] soundArray;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
    public void PlaySound(int soundIndex) {
        audioSource.clip = soundArray[soundIndex];
        audioSource.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
