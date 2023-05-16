using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using StarterAssets;

//Ce script sert à associer une fonction à l'action Back 
//Il permet de faire un retour en arrière dans un menu UI

public class MenuInputs : MonoBehaviour
{

    private FirstPerson playerControls;
    private UnityEvent backEvent;
    private InputAction backaction;
    
    //Constructeur
    void Awake(){
        backEvent = new UnityEvent();
        playerControls = new FirstPerson();
    }
    
    //Fonction qui associe la fonction Back à l'action Back défini dans le New Input System
    private void OnEnable()
    {
        backaction = playerControls.MenuNav.Back;
        backaction.Enable();

        backaction.performed += Back;
    }

    //Fonction qui dissocie la fonction Back à l'action Back défini dans le New Input System
    private void OnDisable()
    {
        backaction.Disable();
    }

    //Fonction qui provoque un événement
    public void Back(InputAction.CallbackContext context)
    {
        backEvent.Invoke();
    }

    //Fonction qui effectue un retour en arrière
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
