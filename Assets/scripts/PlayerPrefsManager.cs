using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_"; // Intentional trailing underscore -- Complete definition depends on context

    public static void SetMasterVolume (float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.Log("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level) {
        if (level <= SceneManager.sceneCount - 1) {
            PlayerPrefs.SetInt(DIFFICULTY_KEY + level.ToString(), 1); // level.toString() cooresponds to what comes after trailing underscore -- Use 1 for true (no bools)
        } else {
            Debug.Log("Level: " + level + " not in build order");
        }
    }

    public static int GetUnlockLevel() {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static bool IsLevelUnlocked(int level) {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()); // level.toString() cooresponds to what comes after trailing underscore -- Use 1 for true (no bools)
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCount - 1) {
            return isLevelUnlocked;
        } else {
            Debug.Log("Level: " + level + " not in build order");
            return false;
        }
    }

    public static void SetDifficulty(Difficulty difficulty) {
        PlayerPrefs.SetString(DIFFICULTY_KEY, difficulty.ToString()); // Enum is converted to String for storage
    }

    public static string GetDifficulty() {
        return PlayerPrefs.GetString(DIFFICULTY_KEY);
    }
}
