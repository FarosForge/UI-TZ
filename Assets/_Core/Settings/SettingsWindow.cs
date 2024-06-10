using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : Element
{
    [SerializeField] private VirtualButton acceptButton;
    [SerializeField] private VirtualToggle soundsToggle;
    [SerializeField] private VirtualToggle musicToggle;
    [SerializeField] private AnimationUI animationUI;

    private void Start()
    {
        animationUI.PreviewToStart();
    }
    
    public void Init()
    {
        soundsToggle.Init();
        musicToggle.Init();

        soundsToggle.SetToggleState(!AudioManager.instance.IsSoundsMuted);
        musicToggle.SetToggleState(!AudioManager.instance.IsMusicMuted);

        acceptButton.AddListener(() =>
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Config.ClickSound);
            animationUI.PlayOut(); 
        });

        soundsToggle.AddToggleListener(() =>
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Config.ClickSound);
            AudioManager.instance.MuteSounds();
        });

        musicToggle.AddToggleListener(() =>
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Config.ClickSound);
            AudioManager.instance.MuteMusic();
        });

        animationUI.PlayIn();
    }
}
