using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBoot : MonoBehaviour
{
    [SerializeField] private VirtualButton restartButton;
    [SerializeField] private VirtualButton settingsButton;
    [SerializeField] private SettingsWindow settingsWindow;
    
    void Start()
    {
        restartButton.AddListener(() =>
        {
            SceneLoader.LoadScene(GameScenes.Main);
        });

        settingsButton.AddListener(() =>
        {
            settingsWindow.Init();
        });
    }

}
