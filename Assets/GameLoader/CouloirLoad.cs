using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirLoad : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 targetPosition11;
    private Vector3 targetPosition12;
    private FirstPersonController fpscontroller;

    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.Couloir = true;
        targetPosition11 = transform.GetChild(0).position;
        targetPosition12 = transform.GetChild(1).position;

        if (FirstPersonController.Ho11)
        {
            player.transform.position = targetPosition11;
            player.transform.Rotate(0,90,0);
            FirstPersonController.Ho11 = false;
        }

        else if (FirstPersonController.Ho12)
        {
            player.transform.position = targetPosition12;
            //player.transform.Rotate(0,0,0);
            FirstPersonController.Ho12 = false;
        }
    }

}
