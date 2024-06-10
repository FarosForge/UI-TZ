using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private VirtualButton nextButton;
    
    private SaveSystem saveSystem;
    private AudioManager audioManager;

    private void Start()
    {
        saveSystem = SaveSystem.instance;
        audioManager = AudioManager.instance;

        saveSystem.Init();
        audioManager.Init();

        audioManager.PlayMusic();

        nextButton.AddListener(() =>
        {
            audioManager.PlaySound(audioManager.Config.ClickSound);
            SceneLoader.LoadScene(GameScenes.Main);
        });
    }
}
