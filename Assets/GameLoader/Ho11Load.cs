using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Ho11Load : MonoBehaviour
{
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Ho11 = true;
    }
}
