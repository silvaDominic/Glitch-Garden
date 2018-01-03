using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    DefenderManager defenderManager;
    StarDisplay starDisplay;
    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        defenderManager = GameObject.FindObjectOfType<DefenderManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ResetGame();
	}



    private void ResetGame() {
        StarDisplay.starCount = Constants.DEFALT_STAR_COUNT;
        starDisplay.UpdateDisplay();

        defenderManager.ClearGrid();
    }
}
