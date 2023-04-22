using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

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
