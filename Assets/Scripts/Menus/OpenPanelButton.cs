using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Ce script permet d'ouvrir un panneau en faisant appel à la fonction du controller

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private PanelType type;
    [SerializeField] private OpenPanelButton onSwitchBackAction;

    private MenuController controller;
    private MenuInputs inputs;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<MenuController>();
        inputs = controller.GetComponent<MenuInputs>();
    }

    public void OnClick()
    {
        controller.OpenPanel(type);
        if(onSwitchBackAction != null) inputs.SetBackListener(onSwitchBackAction.OnClick);
        else inputs.SetBackListener();
    }
}
