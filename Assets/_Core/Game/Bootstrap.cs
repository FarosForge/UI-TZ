using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private VirtualButton nextButton;

    private void Start()
    {
        AudioManager.instance.PlayMusic();

        nextButton.AddListener(() =>
        {
            AudioManager.instance.PlaySound(AudioManager.instance.Config.ClickSound);
            SceneLoader.LoadScene(GameScenes.Main);
        });
    }
}
