using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButton : MonoBehaviour {

    public Defender defenderPrefab;
    private CustomButton[] buttons;
    public static Defender selectedDefender;

    // Use this for initialization
    void Start () {
        // Retreive all buttons
        buttons = GameObject.FindObjectsOfType<CustomButton>();
        // Initially set all buttons to a custom color (darkgray in this case)
        AllToSameColor(0.25f, 0.25f, 0.25f);
    }

    void OnMouseDown() {
        // Set all buttons to color darkgray
        AllToSameColor(0.25f, 0.25f, 0.25f);
        // Change current button to color white
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }

    private void AllToSameColor(float r, float g, float b, float a = 255) {
        foreach (CustomButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color(r, g, b, a);
        }
    }
}
