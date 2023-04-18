using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using StarterAssets;


public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();

    [SerializeField] private bool gameIsPaused;

    [SerializeField] private MenuController controller;
    
    private FirstPerson playerControls;
    private InputAction menu;
    private FirstPersonController fpscontroller;

    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }

    private void OnEnable()
    {
        menu = playerControls.MenuNav.Pause;
        menu.Enable();
        
        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    public void Pause(InputAction.CallbackContext context)
    {

        gameIsPaused = !gameIsPaused;
        if(gameIsPaused)
        {
            ActivateMenu();
            FirstPersonController.pause = true;
        }
        else 
        {
            DeactivateMenu();
            FirstPersonController.pause = false;   
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenu.SetActive(true);
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(false);
        }
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        controller.OpenPanel(PanelType.Main);
        PauseMenu.SetActive(false);
        foreach (GameObject canva in canvas)
        {
            canva.SetActive(true);
        }
        gameIsPaused = false;
    }
}
