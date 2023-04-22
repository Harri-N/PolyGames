using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class NextDialogue : MonoBehaviour
{
    [SerializeField] private List<Animator> NPCs = new List<Animator>();
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();
    [SerializeField] private GameLoader gameLoader;
    private FirstPerson playerControls;
    private InputAction next;
    private FirstPersonController fpscontroller;

    static public int index = 3;
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
            if(transform.childCount <= 3) {
                fin = true;
            }
            if(transform.childCount > 2) {
                if (!fin)
                {
                    if (transform.childCount > 3)
                    {
                        transform.GetChild(index).gameObject.SetActive(true);
                        index += 1;
                        if (transform.childCount == index)
                        {
                            index = 3;
                            fin = true;
                        }
                    }
                }
                else 
                {
                    gameObject.SetActive(false);
                    foreach (Animator animator in NPCs) {
                        animator.ResetTrigger("Talk");
                    }
                    FirstPersonController.dialogue = false;
                    if (transform.childCount>3)
                    {
                        for (int i=transform.childCount - 1 ; i>2 ; i--) {
                            DestroyImmediate(transform.GetChild(index).gameObject);
                        }
                    }
                    DestroyImmediate(transform.GetChild(2).gameObject);
                    fin = false;
                    foreach (GameObject canva in canvas)
                    {
                        canva.SetActive(true);
                    }
                    if(FirstPersonController.Doyen) {FirstPersonController.DoyenEnd = true;}
                    if(FirstPersonController.MineTalk && !FirstPersonController.MineTalkEnd) {gameLoader.ChangeScene("Mine"); }
                    if (FirstPersonController.MineGame && !FirstPersonController.MineTalk2) {gameLoader.ChangeScene("PlayGround");}
                }
            }
        }
    }
}
