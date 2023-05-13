using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using StarterAssets;


public class MenuInputs : MonoBehaviour
{
    private UnityEvent backEvent;
    private FirstPerson playerControls;
    private InputAction backaction;
    private FirstPersonController fpscontroller;
    
    void Awake(){
        backEvent = new UnityEvent();
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }
    
    private void OnEnable()
    {
        backaction = playerControls.MenuNav.Back;
        backaction.Enable();

        backaction.performed += Back;
    }

    private void OnDisable()
    {
        backaction.Disable();
    }

    public void Back(InputAction.CallbackContext context)
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
