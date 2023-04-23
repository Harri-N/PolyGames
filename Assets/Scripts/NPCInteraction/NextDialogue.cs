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
    private GameObject boxTuto;

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
            //====================== Gestion de l'affichage des tutos ======================//
            if(FirstPersonController.Tuto1 && !FirstPersonController.Tuto1End)
            {
                boxTuto = transform.GetChild(2).gameObject;
                boxTuto.transform.Find("BoxTuto/BoxIconsInteract").gameObject.SetActive(false);
                boxTuto.transform.Find("BoxTuto/BoxIconsStart").gameObject.SetActive(false);
                boxTuto.transform.Find("BoxTuto/BoxIconsMove").gameObject.SetActive(false);
                boxTuto.transform.Find("BoxTuto/BoxIconsLook").gameObject.SetActive(false);
                if (index == 4) {boxTuto.transform.Find("BoxTuto/BoxIconsStart").gameObject.SetActive(true);}
                if (index == 6) {boxTuto.transform.Find("BoxTuto/BoxIconsMove").gameObject.SetActive(true);}
                if (index == 7) {boxTuto.transform.Find("BoxTuto/BoxIconsLook").gameObject.SetActive(true);}
                if (index == 8) {boxTuto.transform.Find("BoxTuto/BoxIconsInteract").gameObject.SetActive(true);}
            }
            if(FirstPersonController.Tuto2 && !FirstPersonController.Tuto2End)
            {
                boxTuto = transform.GetChild(2).gameObject;
                boxTuto.transform.Find("BoxTuto/BoxIconsJump").gameObject.SetActive(false);
                boxTuto.transform.Find("BoxTuto/BoxIconsFire").gameObject.SetActive(false);
                if (index == 3) {boxTuto.transform.Find("BoxTuto/BoxIconsJump").gameObject.SetActive(true);}
                if (index == 4) {boxTuto.transform.Find("BoxTuto/BoxIconsFire").gameObject.SetActive(true);}
            }

            //Si un seul dialogue, on est à la fin
            if(transform.childCount <= 3) {
                fin = true;
            }
            
            //Si on est pas à la fin, on passe au dialogue suivant
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

            //Si on arrive à la fin de la discussion
            else 
            {
                //On rend inactif le canva
                gameObject.SetActive(false);

                //On reset l'animation des NPC
                foreach (Animator animator in NPCs) {
                    animator.ResetTrigger("Talk");
                }

                //On réinitialise le booléen dialogue
                FirstPersonController.dialogue = false;

                //On détruit tous les templates de la BoxDialogue 
                if (transform.childCount>3)
                {
                    for (int i=transform.childCount - 1 ; i>2 ; i--) {
                        DestroyImmediate(transform.GetChild(index).gameObject);
                    }
                }
                DestroyImmediate(transform.GetChild(2).gameObject);

                //On réinitialise le bool fin à faux    
                fin = false;

                //On rend de nouveau actif les autres canvas
                foreach (GameObject canva in canvas)
                {
                    canva.SetActive(true);
                }

                //Gestion des étapes dans le jeu
                if(FirstPersonController.Doyen && !FirstPersonController.DoyenEnd) {FirstPersonController.DoyenEnd = true;}
                if(FirstPersonController.MineTalk && !FirstPersonController.MineTalkEnd) {gameLoader.ChangeScene("Mine"); }
                if (FirstPersonController.MineGame && !FirstPersonController.MineTalk2) {gameLoader.ChangeScene("PlayGround");}

                if(FirstPersonController.Tuto1 && !FirstPersonController.Tuto1End) {FirstPersonController.Tuto1End = true;}
                if(FirstPersonController.Tuto2 && !FirstPersonController.Tuto2End) {FirstPersonController.Tuto2End = true;}
            }
            
        }
    }
}
