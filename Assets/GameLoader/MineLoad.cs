using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MineLoad : MonoBehaviour
{
    private FirstPersonController fpscontroller;

    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.MineTalkEnd = true;
    }
}
