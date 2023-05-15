using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;


public class LittleRock : ObjectTake
{
    static public int rocks = 0;
    private FirstPersonController fpscontroller;
    
    private void Awake()
    {
        fpscontroller = GetComponent<FirstPersonController>();
    }
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
