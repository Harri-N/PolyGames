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
            if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                if (!FirstPersonController.pause && !FirstPersonController.dialogue) {
                    //transform.LookAt(npcInteractable.head.transform);
                    npcInteractable.Interact(transform);
                }
            }
            if(collider.TryGetComponent(out DoorInteractable doorInteractable)) {
                if (!FirstPersonController.pause && !FirstPersonController.dialogue) {
                    doorInteractable.ToggleDoor();
                }
                /*
                else if (!FirstPersonController.pause && FirstPersonController.dialogue) { 
                    npcInteractable.Next();
                }
                */
            }
            
        }
    }

    public NPCInteractable GetInteractableObject() {
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>();
        List<DoorInteractable> doorInteractableList = new List<DoorInteractable>();
        float interactRange = 2f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                npcInteractableList.Add(npcInteractable);
            }
            if(collider.TryGetComponent(out DoorInteractable doorInteractable)) {
                doorInteractableList.Add(doorInteractable);
            }
        }

        NPCInteractable closestNPCInteractable = null;
        foreach (NPCInteractable npcInteractable in npcInteractableList) {
            if (closestNPCInteractable == null) {
                closestNPCInteractable = npcInteractable;
            } else {
                if (Vector3.Distance(transform.position, npcInteractable.transform.position) <
                    Vector3.Distance(transform.position, closestNPCInteractable.transform.position)) {
                        closestNPCInteractable = npcInteractable;
                    }
            }
        }
        return closestNPCInteractable;
    }

    public DoorInteractable GetInteractableDoor() {
        List<DoorInteractable> doorInteractableList = new List<DoorInteractable>();
        float interactRange = 2f;
        Collider [] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if(collider.TryGetComponent(out DoorInteractable doorInteractable)) {
                doorInteractableList.Add(doorInteractable);
            }
        }

        DoorInteractable closestDoorInteractable = null;
        foreach (DoorInteractable doorInteractable in doorInteractableList) {
            if (closestDoorInteractable == null) {
                closestDoorInteractable= doorInteractable;
            } else {
                if (Vector3.Distance(transform.position, doorInteractable.transform.position) <
                    Vector3.Distance(transform.position, closestDoorInteractable.transform.position)) {
                        closestDoorInteractable = doorInteractable;
                    }
            }
        }
        return closestDoorInteractable;
    }

}
