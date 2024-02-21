using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SounControll : MonoBehaviour
{
    public Image toggleImage; 
    public Sprite soundOnSprite; 
    public Sprite soundOffSprite; 

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

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled; 
        UpdateSoundSprite(soundEnabled);
    }

    public void UpdateSoundSprite(bool soundEnabled)
    {
        
        if(soundEnabled == true) 
        {
            toggleImage.sprite = soundOnSprite;
            PlayerPrefs.SetInt(SoundEnabledKey, 1);
        }
        else
        {
            toggleImage.sprite = soundOffSprite;
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

