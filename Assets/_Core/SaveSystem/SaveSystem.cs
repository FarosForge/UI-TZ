using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private SaveData data;

    private const string GAME_ID = "Game_Id";

    public SaveData Data { get => data; }

    public void Init()
    {
        DontDestroyOnLoad(this);
        data = new SaveData();
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt(GAME_ID + "music_mute", AudioManager.instance.IsMusicMuted ? 1 : 0);
        PlayerPrefs.SetInt(GAME_ID + "sounds_mute", AudioManager.instance.IsSoundsMuted ? 1 : 0);
    }

    private void Load()
    {
        data.musicMuted = PlayerPrefs.GetInt(GAME_ID + "music_mute", 0);
        data.soundsMuted = PlayerPrefs.GetInt(GAME_ID + "sounds_mute", 0);
    }
}
