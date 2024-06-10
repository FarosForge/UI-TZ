using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private static Image fade;
    private static TweenerCore<Color, Color, ColorOptions> _fadeAinm;

    private static Action _actionAfter;
    private static bool _startFade = false;
    public GameScenes startScene;

    private void Start()
    {
        DontDestroyOnLoad(this);
        fade = GetComponentInChildren<Image>();
    }

    public static void LoadScene(GameScenes scene)
    {
        Fade(scene, null);
    }

    public static void LoadScene(GameScenes scene, Action endEction)
    {
        Fade(scene, endEction);
    }

    private static void Fade(GameScenes scene, Action end)
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => FadeIn(Color.black, () => SceneManager.LoadScene(scene.ToString())))
            .AppendCallback(() => end?.Invoke())
            .AppendInterval(2)
            .AppendCallback(() => FadeOut());
    }

    public static void Fade(Action action, float time = 2)
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() => FadeIn(Color.black, () => action?.Invoke()))
            .AppendInterval(time)
            .AppendCallback(() => FadeOut());
    }

    public static void FadeIn(Color color, Action actionAfter = null)
    {
        _fadeAinm.Kill();

        if (_startFade)
        {
            _actionAfter?.Invoke();
            _actionAfter = actionAfter;
            fade.DOColor(color, 1f).OnComplete(() =>
            {
                _actionAfter?.Invoke();
            });
        }
        else
        {
            _startFade = true;
            color.a = 0;
            fade.enabled = true;
            fade.color = color;
            _actionAfter = actionAfter;
            fade.DOFade(1, 1).OnComplete(() =>
            {
                _startFade = false;
                _actionAfter?.Invoke();
            });
        }
    }
    private static void FadeOut()
    {
        _fadeAinm = fade.DOFade(0, 1).OnComplete(() => fade.enabled = false);
    }
}