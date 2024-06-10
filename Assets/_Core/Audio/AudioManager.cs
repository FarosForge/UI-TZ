using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioConfig config;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    public AudioConfig Config { get => config; }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void MuteMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MuteSounds()
    {
        soundsSource.mute = !soundsSource.mute;
    }

    public void PlayMusic()
    {
        musicSource.clip = config.Music;
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        soundsSource.PlayOneShot(clip);
    }
}
