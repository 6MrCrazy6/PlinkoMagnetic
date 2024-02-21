using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTransitionSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundClip;

    public GameObject activateObject;
    public GameObject deactivateObject;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TransitionObject()
    {
        StartCoroutine(LoadSceneAfterSound());
    }

    IEnumerator LoadSceneAfterSound()
    {
        if (soundClip != null)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
            yield return new WaitForSeconds(soundClip.length);
        }

        activateObject.SetActive(false);
        deactivateObject.SetActive(true);
    }
}
