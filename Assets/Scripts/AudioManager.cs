using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    
    
    private AudioSource musicSource;
    private AudioSource sfxSource;
    
    protected override void Awake()
    {
        base.Awake();
        musicSource = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.volume = 1;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        if (sfxClip)
        {
            sfxSource.PlayOneShot(sfxClip);
        }
    }
    
    public void PlaySFX(AudioClip sfxClip, float volume)
    {
        if (sfxClip)
        {
            sfxSource.PlayOneShot(sfxClip, volume);
        }
    }
}
