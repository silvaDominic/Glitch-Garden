using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] LevelMusicChangeArray;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Plays music clip on load of level
    public void OnLevelLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log(scene.buildIndex);
        AudioClip currentLevelMusic = LevelMusicChangeArray[scene.buildIndex];
        if (currentLevelMusic) {
            audioSource.clip = currentLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
