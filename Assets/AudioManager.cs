using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    // tao bien luu tru audio clip

    public AudioClip musicClip;
    public AudioClip ancaClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
        
    }

    
}
