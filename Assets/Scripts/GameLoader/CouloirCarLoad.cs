using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

//Ce script stocke la position de départ de la voiture pour permettre de réapparaitre à cet endroit

public class CouloirCarLoad : MonoBehaviour
{
    [SerializeField] private Transform car;
    private FirstPersonController fpscontroller;
    private void Awake() {
        fpscontroller = GetComponent<FirstPersonController>();
        if (FirstPersonController.etape == 4) {FirstPersonController.MecaTalk = true;}
        transform.Find("StartPoint").position = car.transform.position;
        transform.Find("StartPoint").rotation = car.transform.rotation;
    }



    public void Reset()
    {
        car.transform.position = transform.Find("StartPoint").position;
        car.transform.rotation =  transform.Find("StartPoint").rotation;
    }
}
