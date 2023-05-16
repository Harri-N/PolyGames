using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

public class ObjectTake : InteractableObject
{
    public virtual void Take()
    {
        Destroy(gameObject, 0f);
            
    }

    public override void Interact() 
    {
        Take();
    }
}
