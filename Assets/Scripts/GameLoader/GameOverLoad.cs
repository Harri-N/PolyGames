using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

//Ce script gère la scène gameOver

public class GameOverLoad : MonoBehaviour
{
    private string nom_scene;
    [SerializeField] private GameLoader gameLoader;

    private void Awake() 
    {   
        //On reset dans le couloir si on rate le jeu de la voiture
        if (FirstPersonController.etape < 8) {
            nom_scene = "CouloirCar";
			FirstPersonController.MecaTalkEnd = false;
			FirstPersonController.MecaCar = false;
			FirstPersonController.MecaGame = false;
            FirstPersonController.GameOver = false;
            FirstPersonController.etape = 4;
        }

        //On le combat final dans la cour si on rate le jeu du dragon
        else {
            nom_scene = "Cour";
			FirstPersonController.FortempsTalkEnd = false;
			FirstPersonController.DragonGameBegin = false;
			FirstPersonController.DragonGameBegin2 = false;
            FirstPersonController.TutoDragon = false;
            FirstPersonController.TutoDragonEnd = false;
			FirstPersonController.DragonGame = false;
            FirstPersonController.GameOver = false;
            FirstPersonController.Couloir = true;
            FirstPersonController.etape = 14;
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
