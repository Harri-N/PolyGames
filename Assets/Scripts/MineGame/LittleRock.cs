using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;


//Classe d�riv�e de ObjectTake
//ObjectTake d�rive elle-m�me de la classe InteractableObject (qui englobe tous les objets avec lesquels
//l'utilisatuer peut int�ragir dans le jeu (avec la touche E) et qui affiche les textes li�s aux int�ractions
//ObjectTake englobe normalment tous les objets que le joueur prend dans le jeu (en r�alit�, cette fonction d�truit l'objet)
public class LittleRock : ObjectTake
{
    static public int rocks = 0;
    private FirstPersonController fpscontroller;
    
    private void Awake()
    {
        fpscontroller = GetComponent<FirstPersonController>();
    }
    //red�finition de la fonction Take()
    //Cette fonction compte le nombre de cailloux pris par le joueur
    //S'ils sont bien au nombre de 3, le bool�en est chang� pour indiquer que le jeu est fini
    public override void Take() 
    {
        base.Take();
        rocks += 1;
        if (rocks == 3)
        {
            FirstPersonController.MineGame = true;
        }    
    }
}
