using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StarTrophy : Defender {

    private StarDisplay starDisplay;

    // Use this for initialization
    void Start() {
        base.Start();

        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public override void Update() {
        // No Update logic neccessary for StarTrophy
    }

    private void AddStars(int amount) {
        starDisplay.AddStars(amount);
    }
}
