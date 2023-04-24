using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : InteractableObject
{
    [SerializeField] private GameLoader gameLoader;
    [SerializeField] private string scene;
    
    
    public void ToggleDoor()
    {
        Debug.Log("Door");
        gameLoader.ChangeScene(scene);
    }
}
