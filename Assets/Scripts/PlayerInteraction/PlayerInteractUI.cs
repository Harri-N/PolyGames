using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Ce script permet de changer le texte d'interaction qd on se rapproche d'un objet

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    //fonction qui se lance à chaque frame
    private void Update() {

        //Il y a un objet à proximité, on affiche du texte
        if(playerInteract.GetInteractableObject() != null) {
            Show(playerInteract.GetInteractableObject());
        }
        
        //Sinon on cache le canva
        else {
            Hide();
        }
    }

    //Fonction qui affiche du texte
    private void Show(InteractableObject interactableObject) {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactableObject.GetInteractText();
   }

   //fonction qui cache le canva 
   private void Hide() {
        containerGameObject.SetActive(false);
   }
}
