using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : Element
{
    [SerializeField] private VirtualButton acceptButton;
    [SerializeField] private VirtualToggle soundsToggle;
    [SerializeField] private VirtualToggle musicToggle;

    private void Start()
    {
        soundsToggle.Init();
        musicToggle.Init();

        acceptButton.AddListener(() =>
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Config.ClickSound);
            Deactivate();
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

        Deactivate();
    }
    
    public void Init()
    {
        Activate();
    }
}
