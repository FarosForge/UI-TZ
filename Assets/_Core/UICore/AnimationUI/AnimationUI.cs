using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] private List<AnimationState> states = new();

    public void PlayIn()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (var state in states)
        {
            switch (state.Type)
            {
                case AnimationStateType.Animation:
                    sequence.Append(state.InvokeAnimationState(false));
                    break;
                case AnimationStateType.Wait:
                    sequence.AppendInterval(state.delay);
                    break;
                case AnimationStateType.Fade:
                    sequence.Append(state.InvokeFadeState(false));
                    break;
                case AnimationStateType.FadeImage:
                    sequence.Append(state.InvokeFadeState(false));
                    break;
            }
        }

        sequence.Play();
    }

    public void PlayOut()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (var state in states)
        {
            switch (state.Type)
            {
                case AnimationStateType.Animation:
                    sequence.Join(state.InvokeAnimationState(true));
                    break;
                case AnimationStateType.Wait:
                    sequence.Join(sequence.AppendInterval(state.delay));
                    break;
                case AnimationStateType.Fade:
                    sequence.Join(state.InvokeFadeState(true));
                    break;
                case AnimationStateType.FadeImage:
                    sequence.Join(state.InvokeFadeState(true));
                    break;
            }
        }

        sequence.Play();
    }

    public void PreviewToStart()
    {
        foreach (var state in states)
        {
            if(state.Type == AnimationStateType.Animation)
            {
                state.PreviewToStart();
            }
        }
    }
}
