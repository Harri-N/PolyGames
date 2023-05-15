using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactText;
    
    public virtual void Interact(Transform interactorTransform) {}
    public virtual void Interact() {}

    public string GetInteractText() {
        return interactText;
    }

    public void SetInteractText(string text) {interactText = text;}
    
}
