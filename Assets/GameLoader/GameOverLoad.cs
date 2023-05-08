using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameOverLoad : MonoBehaviour
{
    private string nom_scene;

    private void Awake() 
    {
        if (FirstPersonController.etape < 6) {nom_scene = "CouloirCar";}
        else {nom_scene = "Cour";}
    }
}
