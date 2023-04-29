using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CouloirCarLoad : MonoBehaviour
{
    [SerializeField] private Transform car;
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        FirstPersonController.MecaTalk = true;
        transform.GetChild(2).position = car.transform.position;
    }

    public void Reset() {
        car.transform.position = transform.GetChild(2).position;
        car.transform.rotation =  Quaternion.Euler(0f, 0f, 0f); 
    }
}
