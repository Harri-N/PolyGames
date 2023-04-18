using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]

public class MenuInputs : MonoBehaviour
{
    private PlayerInput inputs;

    private UnityEvent backEvent;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        backEvent = new UnityEvent();
    }

    private void OnBack()
    {
        backEvent.Invoke();
    }

    public void SetBackListener(UnityAction _call)
    {
        backEvent.RemoveAllListeners();
        backEvent.AddListener(_call);
    }
    public void SetBackListener()
    {
        backEvent.RemoveAllListeners();
    }

}
