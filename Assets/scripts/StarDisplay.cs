using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text displayText;
    public static int starCount = Constants.DEFALT_STAR_COUNT;

	// Use this for initialization
	void Start () {
        displayText = GetComponent<Text>();
        displayText.text = starCount.ToString();
        UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount) {
        starCount += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount) {
        starCount -= amount;
        UpdateDisplay();
    }

    public void UpdateDisplay() {
        displayText.text = starCount.ToString();
    }
}
