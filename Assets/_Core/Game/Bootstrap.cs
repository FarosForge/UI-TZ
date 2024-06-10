using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private VirtualButton nextButton;

    private void Start()
    {
        nextButton.AddListener(() =>
        {
            Debug.Log("Click");
            SceneLoader.LoadScene(GameScenes.Main);
        });
    }
}
