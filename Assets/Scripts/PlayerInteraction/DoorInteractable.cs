using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
