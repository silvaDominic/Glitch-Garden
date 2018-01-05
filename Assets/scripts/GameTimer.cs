using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Time in seconds")]
    public float levelDuration;
    private Slider gameClock;
    private LevelManager levelManager;
    private bool TimeIsUp = false;

    // Use this for initialization
    void Start() {
        gameClock = GetComponent<Slider>();
        gameClock.maxValue = levelDuration;

        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        levelDuration -= Time.deltaTime;
        gameClock.value = levelDuration;

        if (levelDuration <= 0 && !TimeIsUp) {
            levelManager.LoadLevel(Constants.WIN_SCREEN);
            TimeIsUp = true;
        }
    }
}