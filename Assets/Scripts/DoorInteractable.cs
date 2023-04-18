using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private string scene;
    
    public void ToggleDoor()
    {
        Debug.Log("Door");
        gamemanager.ChangeScene(scene);
    }

    public string GetInteractText() {
        return interactText;
    }
}
