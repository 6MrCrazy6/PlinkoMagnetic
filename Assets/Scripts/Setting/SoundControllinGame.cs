using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllinGame : MonoBehaviour
{
    private const string SoundEnabledKey = "SoundEnabled";
    private bool soundEnabled;

    private void Start()
    {
        if (PlayerPrefs.GetInt(SoundEnabledKey) == 0)
        {
            soundEnabled = false;
        }
        else
        {
            soundEnabled = true;
        }

        UpdateSoundSprite(soundEnabled);
    }

    public void UpdateSoundSprite(bool soundEnabled)
    {

        if (soundEnabled == true)
        {
            PlayerPrefs.SetInt(SoundEnabledKey, 1);
        }
        else
        {
            PlayerPrefs.SetInt(SoundEnabledKey, 0);
        }

        PlayerPrefs.Save();
        ApplySoundState();
    }

    private void ApplySoundState()
    {
        GameObject[] allObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in allObjects)
        {
            AudioSource[] audioSources = obj.GetComponentsInChildren<AudioSource>();

            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.enabled = soundEnabled;
            }
        }
    }
}
