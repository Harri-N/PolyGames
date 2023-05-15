using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

//Ce script permet d'associer une fonction à l'action Interact du joueur


public class PlayerInteract : MonoBehaviour
{
    private FirstPerson playerControls;
    private InputAction interaction;
    private FirstPersonController fpscontroller;
    
    [Tooltip("Liste des canvas à désactiver pendant un dialogue")]
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();

    //Constructeur
    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }
    
    //Fonction qui associe la fonction à l'action Interaction
    private void OnEnable()
    {
        interaction = playerControls.Player.Interaction;
        interaction.Enable();

        interaction.performed += Interaction;
    }

    //Fonction qui annule l'action
    private void OnDisable()
    {
        interaction.Disable();
    }

    //Fonction associé à l'action interaction
    //Elle appelle la fonction Interact de l'objet qui peut défini différement en fonction de l'objet
    public void Interaction(InputAction.CallbackContext context)
    {
        //On stocke tous les éléments avec un collider dans un rayon de 2m
        float interactRange = 2f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        //Pour tous ces élements, on effectue une action
        foreach (Collider collider in colliderArray) {

            //Si le jeu n'est pas en pause ou joueur pas dans un dialogue
            if (!FirstPersonController.pause && !FirstPersonController.dialogue)
            {   
                //Si l'objet est de class InteractableObject
                if(collider.TryGetComponent(out InteractableObject interactableObject))
                {   
                    //Si l'objet est un NPC
                    if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {

                        //On rend les autres canvas inactifs et on lance un dialogue
                        foreach (GameObject canva in canvas)
                        {
                            canva.SetActive(false);
                        }
                        npcInteractable.Interact(transform);
                    }

                    //Sinon on appelle la fonction Interact de l'objet
                    else {interactableObject.Interact();}
                }
                    
            }

            
            
        }
    }

    //Fonction qui cherche l'objet le plus proche du joueur
    public InteractableObject GetInteractableObject() {
        List<InteractableObject> interactableObjectList = new List<InteractableObject>();
        float interactRange = 2f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if(collider.TryGetComponent(out InteractableObject interactableObject)) {
                interactableObjectList.Add(interactableObject);
            }
        }

        InteractableObject closestinteractableObject = null;
        foreach (InteractableObject interactableObject in interactableObjectList) {
            if (closestinteractableObject == null) {
                closestinteractableObject = interactableObject;
            } else {
                if (Vector3.Distance(transform.position, interactableObject.transform.position) <
                    Vector3.Distance(transform.position, closestinteractableObject.transform.position)) {
                        closestinteractableObject = interactableObject;
                    }
            }
        }
        return closestinteractableObject;
    }

}
