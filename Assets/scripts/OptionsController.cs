using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    const float DEFAULT_VOLUME = 0.75f;
    const Difficulty DEFAULT_DIFFICULTY = Difficulty.Normal;

    public Slider volumeSlider;

    public LevelManager levelManager;
    private MusicManager musicManager;
    private Difficulty selectedDifficulty;

    private void Start() {
        // Initialized options
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        Debug.Log("On Start: " + (Difficulty)System.Enum.Parse(typeof(Difficulty), PlayerPrefsManager.GetDifficulty()));
        SetDifficulty((Difficulty)System.Enum.Parse(typeof(Difficulty), PlayerPrefsManager.GetDifficulty()));
    }

    private void Update() {
        musicManager.SetVolume(volumeSlider.value); // Changes volume in real time
    }

    // Saves current option settings to player prefs
    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(selectedDifficulty);
        levelManager.LoadLevel("01a-main-menu");
        Debug.Log("Saved");
        Debug.Log("Volume: " + PlayerPrefsManager.GetMasterVolume().ToString());
        Debug.Log("Difficulty: " + PlayerPrefsManager.GetDifficulty().ToString());
    }

    // Sets defualt settings
    public void SetDefaults() {
        volumeSlider.value = DEFAULT_VOLUME;
        SetDifficulty(DEFAULT_DIFFICULTY);
    }

    // Sets difficulty for buttons (workaround since enums aren't supported)
    public void SetDifficulty(Difficulty difficulty) {
        switch (difficulty) {
            case Difficulty.Easy:
                SetEasyDifficulty();
                break;
            case Difficulty.Normal:
                SetNormalDifficulty();
                break;
            case Difficulty.Hard:
                SetHardDifficulty();
                break;
            default:
                break;
        }
    }

    public void SetEasyDifficulty() {
        selectedDifficulty = Difficulty.Easy;
        Button diffButton = GameObject.Find("Easy-Option").GetComponent<Button>();
        ColorBlock cb = diffButton.colors;
        cb.normalColor = cb.highlightedColor;
    }

    public void SetNormalDifficulty() {
        selectedDifficulty = Difficulty.Normal;
        Button diffButton = GameObject.Find("Normal-Option").GetComponent<Button>();
        ColorBlock cb = diffButton.colors;
        cb.normalColor = cb.highlightedColor;
    }

    public void SetHardDifficulty() {
        selectedDifficulty = Difficulty.Hard;
        Button diffButton = GameObject.Find("Hard-Option").GetComponent<Button>();
        ColorBlock cb = diffButton.colors;
        cb.normalColor = cb.highlightedColor;
    }
}
