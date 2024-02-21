using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSound : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(soundEffect);
    }
}
