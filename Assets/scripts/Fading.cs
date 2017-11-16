using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

    public enum FadeType {FadeIn, FadeOut, None}
    public FadeType fadeType;

    public float fadeTime;
    public Color currentColor = Color.black;

    private Image fadePanel;


    private void Start() {
        fadePanel = GetComponent<Image>();
        if (fadeType == FadeType.FadeIn) {
            currentColor.a = 0;
        } else {
            currentColor.a = 1;
        }
    }

    private void Update() {
        switch(fadeType) {
            case FadeType.FadeIn:
                fadeIn();
                break;
            case FadeType.FadeOut:
                fadeOut();
                break;
            case FadeType.None:
                break;
            default:
                break;
        }
    }

    private void fadeIn() {
        if (Time.timeSinceLevelLoad < fadeTime) {
            float alphaChange = Time.deltaTime / fadeTime;
            currentColor.a += alphaChange;
            fadePanel.color = currentColor;
        }
    }

    private void fadeOut() {
        if (Time.timeSinceLevelLoad < fadeTime) {
            float alphaChange = Time.deltaTime / fadeTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        } else {
            gameObject.SetActive(false);
        }
    }
}
