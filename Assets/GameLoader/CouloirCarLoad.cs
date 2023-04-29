using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirCarLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.MecaTalk = true;
    }
}
