using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AnimationState
{
    public AnimationStateType Type;
    public RectTransform transform;
    public Image image;
    public CanvasGroup canvasGroup;
    public float startFade;
    public float delay;
    public Vector2 startPosition;
    public Vector2 moveInPosition;
    public Vector2 moveOutPosition;

    public void PreviewToStart()
    {
        switch (Type)
        {
            case AnimationStateType.Animation:
                if (transform == null) return;

                transform.anchoredPosition = startPosition;
                break;
            case AnimationStateType.Wait:
                break;
            case AnimationStateType.Fade:
                canvasGroup.alpha = delay;
                break;
            case AnimationStateType.FadeImage:
                if (image == null) return;

                Color color = image.color;

                color.a = startFade;

                image.color = color;
                break;
        }


    }

    public void PreviewToInPosition()
    {
        if (transform == null) return;

        transform.anchoredPosition = moveInPosition;
    }

    public void PreviewToOutPosition()
    {
        if (transform == null) return;

        transform.anchoredPosition = moveOutPosition;
    }

    public Tween InvokeAnimationState(bool toOut)
    {
        Tween tween = null;

        if (!toOut)
        {
            PreviewToStart();
            transform.DOAnchorPos(moveInPosition, delay);
        }
        else
        {
            transform.DOAnchorPos(moveOutPosition, delay);
        }   

        return tween;
    }

    public Tween InvokeFadeState(bool toOut)
    {
        Tween tween = null;
        switch (Type)
        {
            case AnimationStateType.Fade:

                if (!toOut)
                {
                    PreviewToStart();
                    DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1f, delay).SetEase(Ease.Linear);
                }
                else
                {
                    DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 0f, delay).SetEase(Ease.Linear);
                }
                break;
            case AnimationStateType.FadeImage:
                if (!toOut)
                {
                    PreviewToStart();
                    image.DOFade(1, 0.5f);
                }
                else
                {
                    image.DOFade(0, 0.5f);
                }
                break;
        }
        

        return tween;
    }
}
