using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fonction qui permet de changer de scène quand le joueur interagit avec une porte

public class DoorInteractable : InteractableObject
{
    [SerializeField] private GameLoader gameLoader;
    [SerializeField] private string scene;
    
    
    public override void Interact() 
    {
        Debug.Log("Door");
        gameLoader.ChangeScene(scene);
    }

    public void SetScene(string scn)
    {
        scene = scn;
    }
}
