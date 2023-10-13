using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManaer : MonoBehaviour
{
    AudioSource audio;
    public AudioClip mainBgmClip;
    private void Start()
    {
       audio = GetComponent<AudioSource>();
        playBgm();
    }

    private void Update()
    {
        
    }

    public void playBgm()
    {
        audio.clip = mainBgmClip;
        audio.Play();
    }
}
