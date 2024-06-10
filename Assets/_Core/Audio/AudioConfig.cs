using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "GameEngine/AudioConfig")]
public class AudioConfig : ScriptableObject
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip clickSound;

    public AudioClip Music { get => music; }
    public AudioClip ClickSound { get => clickSound; }
}
