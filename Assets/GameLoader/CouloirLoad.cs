using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Couloir = true;
    }
}
