using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private bool gameIsPaused;

    [SerializeField] private MenuController controller;
    
    private PlayerInput inputs;
    

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
    }

    private void OnPause()
    {
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused)
        {
            ActivateMenu();
            controller.OpenPanel(PanelType.Main);
        }
        else 
        {
            DeactivateMenu();   
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenu.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenu.SetActive(false);
        gameIsPaused = false;
    }
}
