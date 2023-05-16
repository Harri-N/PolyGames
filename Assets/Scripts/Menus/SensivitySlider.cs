using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

//Ce script permet de changer la sensibilité de la caméra
//Elle associe la valeur du slider dans les paramètres à la vitesse de rotation du personnage

public class SensivitySlider : MonoBehaviour
{
    private Slider sensivity;
    private FirstPersonController fpscontroller;

    private void Awake()
    {
        fpscontroller = GetComponent<FirstPersonController>();
        sensivity = GetComponent<Slider>();
        sensivity.value = FirstPersonController.RotationSpeed;
    }
     private void Update()
     {
        FirstPersonController.RotationSpeed = sensivity.value;
     }
}
