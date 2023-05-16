using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;


//Classe dérivée de ObjectTake
//ObjectTake dérive elle-même de la classe InteractableObject (qui englobe tous les objets avec lesquels
//l'utilisatuer peut intéragir dans le jeu (avec la touche E) et qui affiche les textes liés aux intéractions
//ObjectTake englobe normalment tous les objets que le joueur prend dans le jeu (en réalité, cette fonction détruit l'objet)
public class LittleRock : ObjectTake
{
    static public int rocks = 0;
    private FirstPersonController fpscontroller;
    
    private void Awake()
    {
        fpscontroller = GetComponent<FirstPersonController>();
    }
    //redéfinition de la fonction Take()
    //Cette fonction compte le nombre de cailloux pris par le joueur
    //S'ils sont bien au nombre de 3, le booléen est changé pour indiquer que le jeu est fini
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
