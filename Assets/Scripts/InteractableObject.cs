using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactText;
    
    public string GetInteractText() {
        return interactText;
    }
}
