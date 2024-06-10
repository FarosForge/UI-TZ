using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioConfig config;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    public AudioConfig Config { get => config; }

    public bool IsMusicMuted { get => musicSource.mute; }
    public bool IsSoundsMuted { get => soundsSource.mute; }

    public void Init()
    {
        DontDestroyOnLoad(this);

        musicSource.mute = SaveSystem.instance.Data.musicMuted == 0 ? false : true;
        soundsSource.mute = SaveSystem.instance.Data.soundsMuted == 0 ? false : true;
    }

    public void MuteMusic()
    {
        musicSource.mute = !musicSource.mute;
        SaveSystem.instance.Save();
    }

    public void MuteSounds()
    {
        soundsSource.mute = !soundsSource.mute;
        SaveSystem.instance.Save();
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
