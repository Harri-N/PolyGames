using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameOverLoad : MonoBehaviour
{
    private string nom_scene;
    [SerializeField] private GameLoader gameLoader;

    private void Awake() 
    {
        if (FirstPersonController.etape < 6) {
            nom_scene = "CouloirCar";
			FirstPersonController.MecaTalkEnd = false;
			FirstPersonController.MecaCar = false;
			FirstPersonController.MecaGame = false;
            FirstPersonController.GameOver = false;
        }
        else {
            nom_scene = "Cour";
			FirstPersonController.FortempsTalkEnd = false;
			FirstPersonController.DragonGameBegin = false;
			FirstPersonController.DragonGameBegin2 = false;
			FirstPersonController.DragonGame = false;
            FirstPersonController.GameOver = false;
        }
    }

    public void Recommencer()
    {
        gameLoader.ChangeScene(nom_scene);
    }
    public void Abandonner()
    {
        gameLoader.ChangeScene("Demarrage");
    }
}
