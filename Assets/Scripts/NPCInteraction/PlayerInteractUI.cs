using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update() {
        if(playerInteract.GetInteractableObject() != null) {
            Show(playerInteract.GetInteractableObject());
        } 
        else if (playerInteract.GetInteractableDoor() != null) {
            Show(playerInteract.GetInteractableDoor());
        }
        else {
            Hide();
        }
    }

    private void Show(NPCInteractable npcInteractable) {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = npcInteractable.GetInteractText();
   }
   private void Show(DoorInteractable doorInteractable) {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = doorInteractable.GetInteractText();
   }
   private void Hide() {
        containerGameObject.SetActive(false);
   }
}
