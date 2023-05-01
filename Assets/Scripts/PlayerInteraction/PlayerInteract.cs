using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class PlayerInteract : MonoBehaviour
{
    private FirstPerson playerControls;
    private InputAction interaction;
    private FirstPersonController fpscontroller;
    [SerializeField] private List<GameObject> canvas = new List<GameObject>();

    void Awake(){
        playerControls = new FirstPerson();
        fpscontroller = GetComponent<FirstPersonController>();
    }
    
    private void OnEnable()
    {
        interaction = playerControls.Player.Interaction;
        interaction.Enable();

        interaction.performed += Interaction;
    }

    private void OnDisable()
    {
        interaction.Disable();
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        float interactRange = 2f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {

            if (!FirstPersonController.pause && !FirstPersonController.dialogue)
            {
                if(collider.TryGetComponent(out InteractableObject interactableObject))
                {
                    if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                        //transform.LookAt(npcInteractable.head.transform);
                        foreach (GameObject canva in canvas)
                        {
                            canva.SetActive(false);
                        }
                        npcInteractable.Interact(transform);
                    }
                    else {interactableObject.Interact();}
                }
                    
            }

            
            
        }
    }

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
