using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirtualToggle : VirtualButton
{
    [SerializeField] private GameObject toggleObj;
    [SerializeField] private UnityEvent OnToggleClick;

    public void Init()
    {
        OnToggleClick = new UnityEvent();

        AddListener(() =>
        {
            SetToggleState(!toggleObj.activeSelf);
            OnToggleClick?.Invoke();
        });
    }

    public void AddToggleListener(UnityAction action)
    {
        OnToggleClick.RemoveAllListeners();

        OnToggleClick.AddListener(action);
    }

    public void SetToggleState(bool state)
    {
        toggleObj.SetActive(state);
    }
}
