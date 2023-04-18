using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class NextDialogue : MonoBehaviour
{
    [SerializeField] private List<Animator> NPCs = new List<Animator>();
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    private FirstPerson playerControls;
    private InputAction next;
    private FirstPersonController fpscontroller;

    static public int index = 2;
    private bool fin = false;

    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }
    
    private void OnEnable()
    {
        next = playerControls.Player.Next;
        next.Enable();

        next.performed += Next;
    }

    private void OnDisable()
    {
        next.Disable();
    }

    public void Next(InputAction.CallbackContext context)
    {
        if (FirstPersonController.dialogue && !FirstPersonController.pause)
        {
            if(transform.childCount > 1) {
                if (!fin)
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                    index += 1;
                    if (transform.childCount == index)
                    {
                        index = 2;
                        fin = true;
                    }
                }
                else 
                {
                    gameObject.SetActive(false);
                    foreach (Animator animator in NPCs) {
                        animator.ResetTrigger("Talk");
                    }
                    FirstPersonController.dialogue = false;
                    for (int i=transform.childCount - 1 ; i>1 ; i--) {
                        DestroyImmediate(transform.GetChild(index).gameObject);
                    }
                    DestroyImmediate(transform.GetChild(1).gameObject);
                    fin = false;
                    if(FirstPersonController.Doyen)
                    {
                        FirstPersonController.DoyenEnd = true;
                    }

                    foreach (GameObject canva in canvas)
                    {
                        canva.SetActive(true);
                    }
                }
            }
        }
    }
}
