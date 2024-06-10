using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VirtualToggle : VirtualButton
{
    [SerializeField] private GameObject toggleObj;
    [SerializeField] private UnityEvent OnToggleClick;

    private void Start()
    {
        OnToggleClick = new UnityEvent();

        AddListener(() =>
        {
            toggleObj.SetActive(!toggleObj.activeSelf);
            OnToggleClick?.Invoke();
        });
    }

    public void AddToggleListener(UnityAction action)
    {
        OnToggleClick.RemoveAllListeners();

        OnToggleClick.AddListener(action);
    }
}
