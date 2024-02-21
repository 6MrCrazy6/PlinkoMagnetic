using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    public string sceneName;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadSceneAfterSound());
    } 

    public void StartGame()
    {
        StartCoroutine(LoadSceneAfterSound());
    }

    IEnumerator LoadSceneAfterSound()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.PlayOneShot(soundClip);
            yield return new WaitForSeconds(soundClip.length);
        }

        SceneManager.LoadScene(sceneName);
    }
}
