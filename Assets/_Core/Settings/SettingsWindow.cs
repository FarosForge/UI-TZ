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
        acceptButton.AddListener(() =>
        {
            Deactivate();
        });

        soundsToggle.AddToggleListener(() =>
        {

        });

        musicToggle.AddToggleListener(() =>
        {

        });

        Deactivate();
    }
    
    public void Init()
    {
        Activate();
    }
}
